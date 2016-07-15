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
	public Axis axis = Axis.X;


	private bool keyPressed = false;
	private Vector2 pushVector;


	// This function will just define where to apply the push (the push is applied in FixedUpdate, below)
	void Start()
	{
		if(axis == Axis.X)
		{
			pushVector = new Vector2(pushStrength, 0f); // Horizontal push
		}
		else
		{
			pushVector = new Vector2(0f, pushStrength); // Vertical push
		}
	}


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
			rigidbody2D.AddRelativeForce(pushVector);
		}
	}


	// The list of possible axes (used with the variable axis, at the top)
	public enum Axis
	{
		X,
		Y
	}
}
