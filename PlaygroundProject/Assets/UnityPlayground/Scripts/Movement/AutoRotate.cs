using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Auto Rotate")]
[RequireComponent(typeof(Rigidbody2D))]
public class AutoRotate : Physics2DObject
{

	// This is the force that rotate the object every frame
	public float rotationSpeed = 5;

	private float currentRotation;


	// FixedUpdate is called once per frame
	void FixedUpdate ()
	{
		// Find the right rotation, according to speed
		currentRotation += .02f * rotationSpeed * 10f;

		// Apply the rotation to the Rigidbody2d
		rigidbody2D.MoveRotation(-currentRotation);
	}

	//Draw an arrow to show the direction in which the object will rotate
	void OnDrawGizmosSelected()
	{
		if(this.enabled)
		{
			Utils.DrawRotateArrowGizmo(transform.position, rotationSpeed);
		}
	}
}
