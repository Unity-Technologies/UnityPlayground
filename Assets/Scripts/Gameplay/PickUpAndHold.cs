using UnityEngine;

[AddComponentMenu("Playground/Gameplay/Pick Up And Hold")]
public class PickUpAndHold : MonoBehaviour
{
	//pickup key and drop key could be the same
	public KeyCode pickupKey = KeyCode.B;
	public KeyCode dropKey = KeyCode.B;

	public float pickUpDistance = 2f; // An object need to closer than that distance to be picked up.
	//public float hitToDropObject = Mathf.Infinity; //if the character hits anything with a force stronger than this value, the pickup is dropped

	private Transform carriedObject = null;

	private void Update()
	{
		bool justPickedUpSomething = false;

		if(Input.GetKeyDown(pickupKey)
			&& carriedObject == null)
		{
			//Nothing in hand, we check if something is around and pick it up.
			justPickedUpSomething = PickUp();
			//Debug.Log("Pickup");
		}

		if(Input.GetKeyDown(dropKey)
			&& carriedObject != null
			&& !justPickedUpSomething)
		{
			//We're holding something already, we drop
			Drop();
			//Debug.Log("Drop");
		}
	}

	public void Drop()
	{
		Rigidbody2D rb2d = carriedObject.GetComponent<Rigidbody2D>();
		if(rb2d != null)
		{
			rb2d.bodyType = RigidbodyType2D.Dynamic;
			rb2d.velocity = Vector2.zero;
		}
		//unparenting
		carriedObject.parent = null;
		//hands are free again
		carriedObject = null;
	}

	public bool PickUp()
	{
		//Collect every Pickup around
		GameObject[] pickups = GameObject.FindGameObjectsWithTag("Pickup");

		// Find the closest
		float dist = pickUpDistance;
		for(int i = 0; i < pickups.Length; i++)
		{
			float newDist = (transform.position - pickups[i].transform.position).sqrMagnitude;
			if(newDist  < dist)
			{
				carriedObject = pickups[i].transform;
				dist = newDist;
			}
		}

		// Check if we found something
		if(carriedObject != null)
		{
			//check if another player had it, in this case, steal it
			Transform pickupParent = carriedObject.parent;
			if(pickupParent != null)
			{
				PickUpAndHold pickupScript = pickupParent.GetComponent<PickUpAndHold>();
				if(pickupScript != null)
				{
					pickupScript.Drop();
				}
			}

			carriedObject.parent = gameObject.transform;
			// Set to Kinematic so it will move with the Player
			Rigidbody2D rb2d = carriedObject.GetComponent<Rigidbody2D>();
			if(rb2d != null)
			{
				rb2d.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
			}
			return true;
		}
		else
		{
			return false;
		}
	}
}