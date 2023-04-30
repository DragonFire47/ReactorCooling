using PulsarModLoader.CustomGUI;
using static UnityEngine.GUILayout;

namespace ReactorCooling
{
    class GUI : ModSettingsMenu
    {
        public override void Draw()
        {
            if (PhotonNetwork.isMasterClient)
            {
                if (Button("Reactor Cooling " + (Mod.Enabled ? "Enabled" : "Disabled")))
                {
                    Mod.Enabled.Value = !Mod.Enabled.Value;
                    SyncModMessage.SendAllEnabledState();
                }
            }
            else
            {
                Label($"Local mod controls disabled due to not being host. Host mod: {(Mod.HostEnabled ? "Enabled" : "Disabled")}, Mod is effectively {((Mod.HostEnabled) ? "Enabled" : "Disabled")}");
            }
        }

        public override string Name()
        {
            if (!PhotonNetwork.isMasterClient)
            {
                return "Reactor Cooling: " + (Mod.HostEnabled ? "Enabled" : "Disabled");
            }
            return "Reactor Cooling: " + (Mod.Enabled ? "Enabled" : "Disabled");
        }
    }
}
