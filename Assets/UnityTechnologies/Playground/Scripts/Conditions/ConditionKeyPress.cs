using Playground.BaseClasses;
using UnityEngine;

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

        public KeyCode keyToPress = KeyCode.Space;

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
                    if (Input.GetKeyDown(keyToPress)) ExecuteAllActions(null);
                    break;
                case KeyEventTypes.Released:
                    if (Input.GetKeyUp(keyToPress)) ExecuteAllActions(null);
                    break;
                case KeyEventTypes.KeptPressed:
                    if (Time.time >= timeLastEventFired + frequency
                        && Input.GetKey(keyToPress))
                    {
                        ExecuteAllActions(null);
                        timeLastEventFired = Time.time;
                    }

                    break;
            }
        }
    }
}