using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class DestroyOnCollision : MonoBehaviour
{
	// This function gets called everytime this object collides with another
	private void OnCollisionEnter2D(Collision2D collisionData)
	{
		// Destroy it!
		Destroy(collisionData.gameObject);
	}
}
