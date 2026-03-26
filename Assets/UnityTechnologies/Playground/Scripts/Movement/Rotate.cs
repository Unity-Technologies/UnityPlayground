using Playground.BaseClasses;
using Playground.Utilities;
using UnityEngine;

namespace Playground.Movement
{
    [AddComponentMenu("Playground/Movement/Rotate")]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Rotate : Physics2DObject
    {
        [Header("Input keys")] public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;

        [Header("Rotation")] public float speed = 5f;

        private float spin;

        private void Update()
        {
            // Register the spin from the player input
            spin = InputUtils.GetAxis(Enums.Axes.X, typeOfControl);
        }

        private void FixedUpdate()
        {
            // Apply the torque to the Rigidbody2D
            rigidbody2D.AddTorque(-spin * speed);
        }
    }
}