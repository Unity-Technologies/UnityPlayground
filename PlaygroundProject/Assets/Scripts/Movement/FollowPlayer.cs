using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowPlayer : Physics2DObject
{
	// This is the player the object is going to move towards
	public Enums.Players targetPlayer = Enums.Players.Player;

	[Header("Movement")]
	// Speed used to move towards the player
	public float speed = 1f;

	// Used to decide if the object will look at the player while pursuing him
	public bool lookAtPlayer = false;

	// The direction that will face the player
	public Enums.Directions useSide = Enums.Directions.Up;

	private Transform playerTransform;

	void Start ()
	{
		// Find the player in the scene and store a reference for later use
		playerTransform = GameObject.FindGameObjectWithTag(targetPlayer.ToString()).transform;
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate ()
	{
		//Move towards the player
		rigidbody2D.MovePosition(Vector2.Lerp(transform.position, playerTransform.position, Time.fixedDeltaTime * speed));

		//look towards the player
		if(lookAtPlayer)
		{
			Utils.SetAxisTowards(useSide, transform, playerTransform.position - transform.position);
		}
	}
}
