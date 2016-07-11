using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class DieOnCollision : MonoBehaviour
{
	// assign an effect (explosion) or object to be created when this one dies
	public GameObject deathEffect;


	// Happens when this objects hits another
	void OnCollisionEnter2D(Collision2D collisionData)
	{
		if(deathEffect != null)
		{
			GameObject newObject = Instantiate<GameObject>(deathEffect);
			newObject.transform.position = this.transform.position;
		}

		Destroy(gameObject);
	}
}
