using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class DamagePlayer : MonoBehaviour
{

	// How much damage does the collision make?
	public int damage = 1;

	// This function gets called everytime this object collides with another
	private void OnCollisionEnter2D(Collision2D coll)
	{
		// is the other object a player?
		if(coll.gameObject.CompareTag("Player"))
		{
			PlayerHealth ph = coll.gameObject.GetComponent<PlayerHealth>();
			if(ph != null)
			{
				// subtract health from the player
				ph.SubHealth(damage);
			}
		}
	}
}
