using UnityEngine.InputSystem;

namespace Playground.Utilities
{
    public static class InputUtils
    {
        public static float GetAxis(Enums.Axes axis, Enums.KeyGroups keyGroup)
        {
            Key positiveKey;
            Key negativeKey;
            if (axis == Enums.Axes.X)
            {
                if(keyGroup == Enums.KeyGroups.ArrowKeys)
                {
                    negativeKey = Key.LeftArrow;
                    positiveKey = Key.RightArrow;
                }
                else
                {
                    negativeKey = Key.A;
                    positiveKey = Key.D;
                }
            }
            else
            {
                if (keyGroup == Enums.KeyGroups.ArrowKeys)
                {
                    positiveKey = Key.UpArrow;
                    negativeKey = Key.DownArrow;
                }
                else
                {
                    positiveKey = Key.W;
                    negativeKey = Key.S;
                }
            }
            
            float positiveValue = Keyboard.current[positiveKey].IsPressed() ? 1f : 0f;
            float negativeValue = Keyboard.current[negativeKey].IsPressed() ? -1f : 0f;
            
            return positiveValue + negativeValue;
        }
    }
}