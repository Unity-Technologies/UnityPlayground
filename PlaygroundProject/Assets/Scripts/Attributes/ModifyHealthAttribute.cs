using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Modify Health")]
[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class ModifyHealthAttribute : MonoBehaviour
{

	public int healthChange = -1;


	// This function gets called everytime this object collides with another
	private void OnCollisionEnter2D(Collision2D collisionData)
	{
		HealthSystemAttribute healthScript = collisionData.gameObject.GetComponent<HealthSystemAttribute>();
		if(healthScript != null)
		{
			// subtract health from the player
			healthScript.ModifyHealth(healthChange);
		}
	}

	private void OnTriggerEnter2D(Collider2D colliderData)
	{
		HealthSystemAttribute healthScript = colliderData.gameObject.GetComponent<HealthSystemAttribute>();
		if(healthScript != null)
		{
			// subtract health from the player
			healthScript.ModifyHealth(healthChange);
		}
	}
}
