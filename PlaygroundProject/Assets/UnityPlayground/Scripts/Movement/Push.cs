using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Push")]
[RequireComponent(typeof(Rigidbody2D))]
public class Push : Physics2DObject
{
	[Header("Input key")]

	// the key used to activate the push
	public KeyCode key = KeyCode.Space;

	[Header("Direction and strength")]

	// strength of the push, and the axis on which it is applied (can be X or Y)
	public float pushStrength = 5f;
	public Enums.Axes axis = Enums.Axes.Y;
	public bool relativeAxis = true;


	private bool keyPressed = false;
	private Vector2 pushVector;


	// Read the input from the player
	void Update()
	{
		keyPressed = Input.GetKey(key);
	}


	// FixedUpdate is called every frame when the physics are calculated
	void FixedUpdate()
	{
		if(keyPressed)
		{
			pushVector = Utils.GetVectorFromAxis(axis) * pushStrength;

			//Apply the push
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

	//Draw an arrow to show the direction in which the object will move
	void OnDrawGizmosSelected()
	{
		if(this.enabled)
		{
			float extraAngle = (relativeAxis) ? transform.rotation.eulerAngles.z : 0f;
			pushVector = Utils.GetVectorFromAxis(axis) * pushStrength;
			Utils.DrawMoveArrowGizmo(transform.position, pushVector, extraAngle, pushStrength * .5f);
		}
	}
}
