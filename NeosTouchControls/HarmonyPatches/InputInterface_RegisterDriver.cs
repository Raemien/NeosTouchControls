using BaseX;
using FrooxEngine;
using HarmonyLib;
using NeosTouchControls.Input;

namespace NeosTouchControls.HarmonyPatches
{
    [HarmonyPatch(typeof(InputInterface), "RegisterInputDriver")]
    internal class InputInterface_RegisterDriver
    {
        private static TouchGamepadDriver _gamepad;
        public static bool Prefix(InputInterface __instance, IInputDriver driver)
        {
            if (driver.GetType().Equals(typeof(GamepadDriver)))
            {
                if (_gamepad == null) _gamepad = new TouchGamepadDriver();
                __instance.RegisterInputDriver(_gamepad);
                return true;
            }
            return true;
        }
    }
}
