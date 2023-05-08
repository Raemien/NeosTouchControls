using FrooxEngine;
using HarmonyLib;
using UnityEngine;

namespace NeosTouchControls.HarmonyPatches
{
    [HarmonyPatch(typeof(InputInterface), "ShowKeyboard")]
    internal class InputInterface_ShowKeyboard
    {
        public static bool Prefix(InputInterface __instance, IText targetText, string currentText, KeyboardType keyboardType, bool multiline, bool secure, int characterLimit)
        {
            if (!__instance.Engine.IsMobilePlatform || __instance.VR_Active) return true;
            targetText.SelectionStart = 0;
            var keyboard = TouchScreenKeyboard.Open(currentText, (TouchScreenKeyboardType)keyboardType, true, multiline, secure);
            keyboard.characterLimit = characterLimit;
            return true;
        }
    }
}
