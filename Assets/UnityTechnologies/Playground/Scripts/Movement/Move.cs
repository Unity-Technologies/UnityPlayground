using Playground.BaseClasses;
using Playground.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Playground.Movement
{
	[AddComponentMenu("Playground/Movement/Move")]
	[RequireComponent(typeof(Rigidbody2D))]
	public class Move : Physics2DObject
	{
		[Header("Input keys")]
		public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;

		[Header("Movement")]
		[Tooltip("Speed of movement.")] public float speed = 5f;
		public Enums.MovementType movementType = Enums.MovementType.AllDirections;

		[Header("Orientation")]
		[Tooltip("Whether to orient to a certain direction when moving.")] public bool orientToDirection;
		[Tooltip("The direction to face while moving.")] public Enums.Directions lookAxis = Enums.Directions.Up;

		private Vector2 movementInput, cachedDirection;
		private float moveHorizontal;
		private float moveVertical;
		
		private const float perFrameMultiplier = 5000f;

		private void Update ()
		{
			moveHorizontal = InputUtils.GetAxis(Enums.Axes.X, typeOfControl);
			moveVertical = InputUtils.GetAxis(Enums.Axes.Y, typeOfControl);

			// Zero-out the axes that are not needed, if the movement is constrained
			switch(movementType)
			{
				case Enums.MovementType.OnlyHorizontal:
					moveVertical = 0f;
					break;
				case Enums.MovementType.OnlyVertical:
					moveHorizontal = 0f;
					break;
			}
			
			movementInput = new Vector2(moveHorizontal, moveVertical);

			// Rotate the GameObject towards the direction of movement
			// The axis to look at can be decided with the "axis" variable
			if(orientToDirection)
			{
				if(movementInput.sqrMagnitude >= 0.01f)
				{
					cachedDirection = movementInput;
				}
				
				// Keeping SetAxisTowards outside the if ensures the orientation is preserved,
				// even if other objects collide with this when the player is not moving
				Utils.SetAxisTowards(lookAxis, transform, cachedDirection);
			}
			
			movementInput = movementInput.normalized * Time.smoothDeltaTime;
		}

		// FixedUpdate is called every frame when the physics are calculated
		private void FixedUpdate()
		{
			// Apply the force to the Rigidbody2d
			rigidbody2D.AddForce(movementInput * (speed * perFrameMultiplier));
		}
	}
}