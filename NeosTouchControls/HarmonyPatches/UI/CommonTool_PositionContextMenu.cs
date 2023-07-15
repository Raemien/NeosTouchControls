using FrooxEngine;
using HarmonyLib;

namespace NeosTouchControls.HarmonyPatches
{
    [HarmonyPatch("FrooxEngine.CommonTool+<PositionContextMenu>d__334", "MoveNext")]
    internal class CommonTool_PositionContextMenu
    {
        public static void Postfix(ContextMenu ___menu)
        {
            Slot visual = ___menu.Slot;
            visual.LocalScale *= 1.5f;
        }
    }
}
