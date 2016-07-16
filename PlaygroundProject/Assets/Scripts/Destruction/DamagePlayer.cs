using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class DamagePlayer : MonoBehaviour
{

	// How much damage does the collision make?
	public int damage = 1;

	// This function gets called everytime this object collides with another
	private void OnCollisionEnter2D(Collision2D collisionData)
	{
		// is the other object a player?
		if(collisionData.gameObject.CompareTag("Player")
			|| collisionData.gameObject.CompareTag("Player2"))
		{
			PlayerHealth playerHealthScript = collisionData.gameObject.GetComponent<PlayerHealth>();
			if(playerHealthScript != null)
			{
				// subtract health from the player
				playerHealthScript.SubHealth(damage);
			}
		}
	}
}
