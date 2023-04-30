using HarmonyLib;
using PulsarModLoader;
using PulsarModLoader.MPModChecks;

namespace ReactorCooling
{
    internal class SyncModMessage : ModMessage
    {
        public static string Handle = "ReactorCooling.SyncModMessage";
        public override void HandleRPC(object[] arguments, PhotonMessageInfo sender)
        {
            if (sender.sender == PhotonNetwork.masterClient)
            {
                Mod.HostEnabled = (bool)arguments[0];
            }
        }

        public static void SendAllEnabledState()
        {
            if (PhotonNetwork.isMasterClient)
            {
                foreach (PhotonPlayer player in MPModCheckManager.Instance.NetworkedPeersWithMod(Mod.CachedHarmonyIdent))
                {
                    SendRPC(Mod.CachedHarmonyIdent, Handle, player, new object[] { Mod.Enabled.Value });
                }
            }
        }
    }

    [HarmonyPatch(typeof(PLServer), "LoginMessage")]
    class PlayerConnectedPatch //used to sync the client with the host's settings
    {
        static void Postfix(ref PhotonPlayer newPhotonPlayer)
        {
            if (PhotonNetwork.isMasterClient && MPModCheckManager.Instance.NetworkedPeerHasMod(newPhotonPlayer, Mod.CachedHarmonyIdent))
            {
                ModMessage.SendRPC(Mod.CachedHarmonyIdent, SyncModMessage.Handle, newPhotonPlayer, new object[] { Mod.Enabled.Value });
            }
        }
    }

    [HarmonyPatch(typeof(PLServer), "Start")]
    class ServerStartPatch //resets host setting on server join. Catches cases where user joined game with mod enabled, then moves to a game without the mod.
    {
        static void Postfix()
        {
            Mod.HostEnabled = false;
        }
    }
}
