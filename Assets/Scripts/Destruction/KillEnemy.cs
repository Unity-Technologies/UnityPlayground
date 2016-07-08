using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class KillEnemy : MonoBehaviour
{
	
	// This function gets called everytime this object collides with another
	private void OnCollisionEnter2D(Collision2D coll)
	{
		// is the other object an enemy?
		if(coll.gameObject.CompareTag("Enemy"))
		{
			Destroy(coll.gameObject);
		}
	}

	// Trigger collision, in case the object is used as a projectile
	private void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.CompareTag("Enemy"))
		{
			Destroy(coll.gameObject);
		}
	}
}
