using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class AutoMoveToPlayer : Physics2DObject
{
	// Speed used to move towards the player
	public float speed = 5f;

	private Transform playerTransform;	

	void Start ()
	{
		// Find the player in the scene and store a reference for later use
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate ()
	{
		//Move towards the player
		rigidbody2D.AddForce((playerTransform.position - transform.position) * speed);
	}
}
