using PulsarModLoader;

namespace ReactorCooling
{
    public class Mod : PulsarMod
    {
        public Mod()
        {
            CachedHarmonyIdent = HarmonyIdentifier();
        }

        public override string Version => "1.1.0";

        public override string Author => "Dragon";

        public override string LongDescription => "Adds fire-killer grenade Reactor cooling effect back into the game";

        public override string Name => "ReactorCooling";


        public static string CachedHarmonyIdent;
        public override string HarmonyIdentifier()
        {
            return $"{Author}.{Name}";
        }

        public static SaveValue<bool> Enabled = new SaveValue<bool>("Enabled", true);
        public static bool HostEnabled = false;

        public override bool CanBeDisabled()
        {
            return true;
        }

        public override void Disable()
        {
            Enabled.Value = false;
            SyncModMessage.SendAllEnabledState();
        }

        public override void Enable()
        {
            Enabled.Value = true;
            SyncModMessage.SendAllEnabledState();
        }

        public override bool IsEnabled()
        {
            return Enabled.Value;
        }
    }
}
