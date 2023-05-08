using BaseX;
using FrooxEngine;
using UnityEngine.InputSystem.EnhancedTouch;

namespace NeosTouchControls.Input
{
    public class TouchGamepad
    {
        private InputInterface _input;
        public TouchGamepad(InputInterface input)
        {
            _input = input;
        }

        public bool isTouching
        {
            get { return Touch.activeTouches.Count != 0; }
        }

        public bool yButtonPress
        {
            get { return Touch.activeTouches.Count > 3; }
        }

        public float rightTriggerDist
        {
            get { return GetMultiTap(2) ? 0.0f : 100.0f; }
        }

        public float2 rightStickPos
        {
            get => GetStickPos(_rightStickCenter);
        }

        public float2 leftStickPos
        {
            get => GetStickPos(_leftStickCenter);
        }


        private float2 NormalizeTouch(Touch touch)
        {
            UnityEngine.Vector2 unityPos = touch.screenPosition;
            float2 resolution = (float2)_input.WindowResolution;
            float2 pos = new float2(unityPos.x, unityPos.y);
            if (pos.x == 0.0f || pos.y == 0.0f) return float2.Zero;
            return float2.Divide(ref pos, ref resolution);
        }

        private float2 GetStickPos(float2 centerPos)
        {
            float2 stick = new float2(0.0f, 0.0f);
            foreach (var touch in Touch.activeTouches)
            {
                if (touch.pressure < 0.1f) continue;
                float2 fingerPos = NormalizeTouch(touch);
                float2 diff = centerPos - fingerPos;

                // TODO: Use ^2 magnitude for faster distance calculation
                float dist = MathX.Abs(diff.Magnitude);
                UniLog.Log(string.Format("[NeosAndroidDebug] Dist is {0:F4}", dist));
                if (dist > 0.2f) continue;
                if (dist > MathX.Abs(stick.Magnitude)) stick = diff;
            }
            return stick * -5.0f;
        }

        private bool GetMultiTap(int count)
        {
            foreach (var touch in Touch.activeTouches)
            {
                if (touch.tapCount == count) return true;
            }
            return false;
        }

        private readonly float2 _leftStickCenter = new float2(0.3f, 0.4f);
        private readonly float2 _rightStickCenter = new float2(0.7f, 0.6f);
    }
}
