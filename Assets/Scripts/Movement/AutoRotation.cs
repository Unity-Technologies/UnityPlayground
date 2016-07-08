using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class AutoRotation : Physics2DObject
{

	// This is the force that rotate the object every frame
	public float rotationSpeed = 5;

	private float currentRotation;


	// FixedUpdate is called once per frame
	void FixedUpdate ()
	{
		currentRotation += .02f * rotationSpeed * 10f;

		// Apply the rotation to the Rigidbody2d
		rb2D.MoveRotation(currentRotation);
	}
}
