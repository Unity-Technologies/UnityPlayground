using Playground.BaseClasses;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Playground.Conditions
{
    [AddComponentMenu("Playground/Conditions/Condition Key Press")]
    public class ConditionKeyPress : ConditionBase
    {
        public enum KeyEventTypes
        {
            JustPressed,
            Released,
            KeptPressed
        }

        public Key keyToPress = Key.Space;

        [Header("Type of Event")] public KeyEventTypes eventType = KeyEventTypes.JustPressed;

        public float frequency = 0.5f;

        private float timeLastEventFired;


        private void Start()
        {
            timeLastEventFired = -frequency;
        }


        private void Update()
        {
            switch (eventType)
            {
                case KeyEventTypes.JustPressed:
                    if (Keyboard.current[keyToPress].wasPressedThisFrame) ExecuteAllActions(null);
                    break;
                case KeyEventTypes.Released:
                    if (Keyboard.current[keyToPress].wasReleasedThisFrame) ExecuteAllActions(null);
                    break;
                case KeyEventTypes.KeptPressed:
                    if (Time.time >= timeLastEventFired + frequency
                        && Keyboard.current[keyToPress].IsPressed())
                    {
                        ExecuteAllActions(null);
                        timeLastEventFired = Time.time;
                    }

                    break;
            }
        }
    }
}