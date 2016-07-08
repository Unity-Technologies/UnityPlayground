using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class AutoMoveToPlayer : Physics2DObject
{
	public float speed = 5f;

	private Transform playerTransform;	

	void Start ()
	{
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate ()
	{
		//Move towards the player
		rb2D.AddForce((playerTransform.position - transform.position) * speed);
	}
}
