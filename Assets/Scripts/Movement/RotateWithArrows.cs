using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class RotateWithArrows : Physics2DObject
{
	
	[Header("Rotation")]
	public float speed = 5f;
	
	private float spin;
	
	
	// Update gets called every frame
	void Update ()
	{	
		// Register the spin from the player input
		spin = Input.GetAxis("Horizontal");
	}
	

	// FixedUpdate is called every frame when the physics are calculated
	void FixedUpdate ()
	{
		// Apply the torque to the Rigidbody2D
		rigidbody2D.AddTorque(-spin * speed);
	}
}
