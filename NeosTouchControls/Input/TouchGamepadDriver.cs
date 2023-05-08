using BaseX;
using FrooxEngine;

namespace NeosTouchControls.Input
{
    public class TouchGamepadDriver : IInputDriver
    {
        private InputInterface _inputInterface;
        private TouchGamepad _touchGamepad;
        private StandardGamepad _gamepad;
        public void RegisterInputs(InputInterface inputInterface)
        {
            _inputInterface = inputInterface;
            UniLog.Log("[NeosAndroidInput] Registered TouchGamepadDriver!");
        }

        public void UpdateInputs(float deltaTime)
        {
            if (_touchGamepad == null)
            {
                _touchGamepad = new TouchGamepad(_inputInterface);
                _gamepad = _inputInterface.CreateDevice<StandardGamepad>("Touch Controls");
            }

            if (_touchGamepad.isTouching && deltaTime < 0.8f)
            {
                this._gamepad.A.UpdateState(false);
                this._gamepad.B.UpdateState(false);
                this._gamepad.X.UpdateState(false);
                this._gamepad.Y.UpdateState(_touchGamepad.yButtonPress);
                this._gamepad.LeftBumper.UpdateState(false);
                this._gamepad.RightBumper.UpdateState(false);
                this._gamepad.LeftThumbstick.UpdateValue(_touchGamepad.leftStickPos, deltaTime);
                this._gamepad.LeftThumbstickClick.UpdateState(false);
                this._gamepad.RightThumbstick.UpdateValue(_touchGamepad.rightStickPos, deltaTime);
                this._gamepad.RightThumbstickClick.UpdateState(false);
                this._gamepad.LeftTrigger.UpdateValue(0f, deltaTime);
                this._gamepad.RightTrigger.UpdateValue(_touchGamepad.rightTriggerDist, deltaTime);
                this._gamepad.UpdateDPad(false, false, false, false, deltaTime);
                this._gamepad.Menu.UpdateState(false);
                this._gamepad.Start.UpdateState(false);
            }
            else
            {
                this._gamepad.A.UpdateState(false);
                this._gamepad.B.UpdateState(false);
                this._gamepad.X.UpdateState(false);
                this._gamepad.Y.UpdateState(false);
                this._gamepad.LeftBumper.UpdateState(false);
                this._gamepad.RightBumper.UpdateState(false);
                this._gamepad.LeftThumbstick.UpdateValue(default(float2), deltaTime);
                this._gamepad.LeftThumbstickClick.UpdateState(false);
                this._gamepad.RightThumbstick.UpdateValue(default(float2), deltaTime);
                this._gamepad.RightThumbstickClick.UpdateState(false);
                this._gamepad.LeftTrigger.UpdateValue(0f, deltaTime);
                this._gamepad.RightTrigger.UpdateValue(0f, deltaTime);
                this._gamepad.UpdateDPad(false, false, false, false, deltaTime);
                this._gamepad.Menu.UpdateState(false);
                this._gamepad.Start.UpdateState(false);
            }
        }

        public int UpdateOrder { get => 0; }

        public void CollectDeviceInfos(DataTreeList list)
        {

        }
    }
}
