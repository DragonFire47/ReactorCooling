using PulsarPluginLoader;

namespace ReactorCooling
{
    public class Plugin : PulsarPlugin
    {
        public override string Version => "1.0.0";

        public override string Author => "Dragon";

        public override string ShortDescription => "Adds fire extinguisher and fire-killer grenade cooling back into the game";

        public override string LongDescription => base.LongDescription;

        public override string Name => "ReactorCooling";

        public override string HarmonyIdentifier()
        {
            return "Dragon.ReactorCooling";
        }
    }
}
