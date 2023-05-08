using FrooxEngine;
using HarmonyLib;

namespace NeosTouchControls.HarmonyPatches
{
    //[HarmonyPatch(typeof(TouchDriver), "UpdateInputs")]
    //internal class TouchDriver_UpdateInputs
    //{
    //    public static bool Prefix(TouchDriver __instance, InputInterface ___input)
    //    {
    //        if (___input == null) return true;
    //        if (Touch.activeTouches.Count == 1)
    //        {
    //            Vector2 normalizedPos = pos / newres;
    //            UniLog.Log(string.Format("[NeosAndroidDebug] Screen Position: ({0:F4}, {1:F4})", normalizedPos.x, normalizedPos.y));
    //        }
    //        return true;
    //    }
    //}
}
