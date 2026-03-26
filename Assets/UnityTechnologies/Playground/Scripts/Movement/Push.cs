using Playground.BaseClasses;
using Playground.Utilities;
using UnityEngine;

namespace Playground.Movement
{
	[AddComponentMenu("Playground/Movement/Push")]
	[RequireComponent(typeof(Rigidbody2D))]
	public class Push : Physics2DObject
	{
		[Header("Input key")]

		// The key used to activate the push
		public KeyCode key = KeyCode.Space;

		[Header("Direction and strength")]

		// Strength of the push, and the axis on which it is applied (can be X or Y)
		public float pushStrength = 5f;
		public Enums.Axes axis = Enums.Axes.Y;
		public bool relativeAxis = true;

		private bool keyPressed = false;
		private Vector2 pushVector;

		// Read the input from the player
		private void Update()
		{
			keyPressed = Input.GetKey(key);
		}

		private void FixedUpdate()
		{
			if(keyPressed)
			{
				pushVector = Utils.GetVectorFromAxis(axis) * pushStrength;

				// Apply the push
				if(relativeAxis)
				{
					rigidbody2D.AddRelativeForce(pushVector);
				}
				else
				{
					rigidbody2D.AddForce(pushVector);
				}
			}
		}

		// Draw an arrow to show the direction in which the object will move
		private void OnDrawGizmosSelected()
		{
			if(enabled)
			{
				float extraAngle = (relativeAxis) ? transform.rotation.eulerAngles.z : 0f;
				pushVector = Utils.GetVectorFromAxis(axis) * pushStrength;
				Utils.DrawMoveArrowGizmo(transform.position, pushVector, extraAngle, pushStrength * .5f);
			}
		}
	}
}
