using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class AutoPush : Physics2DObject
{

	[Header("Direction of the push")]

	// These are the forces that will push the object every frame
	// don't forget they can be negative too!
	public float horizontalPush = 1;
	public float verticalPush = 0;

	
	// FixedUpdate is called once per frame
	void FixedUpdate ()
	{
		// Apply the force to the Rigidbody2d
		rb2D.AddForce(new Vector2(horizontalPush, verticalPush) * 2f);
	}
}
