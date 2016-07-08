using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveWithArrows : Physics2DObject
{

	[Header("Movement")]
	public float speed = 5f;

	private Vector2 movement;
	private float moveHorizontal;
	private float moveVertical;


	// Update gets called every frame
	void Update ()
	{	
		// Moving with the arrow keys
		moveHorizontal = Input.GetAxis("Horizontal");
		moveVertical = Input.GetAxis("Vertical");
		
		movement = new Vector2(moveHorizontal, moveVertical);
	}


	void FixedUpdate ()
	{
		// Apply the force to the Rigidbody2d
		rb2D.AddForce(movement * speed);
	}
}
