using PulsarModLoader;

namespace ReactorCooling
{
    public class Mod : PulsarMod
    {
        public override string Version => "1.0.0";

        public override string Author => "Dragon";

        public override string LongDescription => "Adds fire-killer grenade Reactor cooling effect back into the game";

        public override string Name => "ReactorCooling";

        public override string HarmonyIdentifier()
        {
            return "Dragon.ReactorCooling";
        }
    }
}
