using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PushWithButton : Physics2DObject
{
	[Header("Input key")]

	// the key used to activate the push
	public KeyCode key = KeyCode.Space;

	[Header("Direction and strength")]

	// strength of the push, and the axis on which it is applied (can be X or Y)
	public float pushStrength = 10f;
	public Enums.Axes axis = Enums.Axes.X;
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
			if(axis == Enums.Axes.X)
			{
				pushVector = new Vector2(pushStrength, 0f); // Horizontal push
			}
			else
			{
				pushVector = new Vector2(0f, pushStrength); // Vertical push
			}

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
}
