using Playground.BaseClasses;
using Playground.Utilities;
using UnityEngine;

namespace Playground.Movement
{
    [AddComponentMenu("Playground/Movement/Auto Rotate")]
    [RequireComponent(typeof(Rigidbody2D))]
    public class AutoRotate : Physics2DObject
    {
        // This is the force that rotate the object every frame
        public float rotationSpeed = 5;

        // FixedUpdate is called once per frame
        private void FixedUpdate()
        {
            // Rotate a bit more from the current rotation, according to speed (positive speed is clockwise)
            rigidbody2D.MoveRotation(rigidbody2D.rotation - rotationSpeed * 10f * Time.fixedDeltaTime);
        }

        //Draw an arrow to show the direction in which the object will rotate
        private void OnDrawGizmosSelected()
        {
            if (enabled) Utils.DrawRotateArrowGizmo(transform.position, rotationSpeed);
        }
    }
}