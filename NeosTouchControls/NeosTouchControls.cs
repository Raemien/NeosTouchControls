using HarmonyLib;
using NeosModLoader;

namespace NeosTouchControls
{
    public class NeosTouchControls : NeosMod
    {
        public override string Name => "NeosTouchControls";
        public override string Author => "Raemien";
        public override string Version => "0.1.0";
        public override string Link => "https://github.com/Raemien/NeosTouchControls";
        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("net.raemien.TouchControls");
            harmony.PatchAll();
        }
    }
}