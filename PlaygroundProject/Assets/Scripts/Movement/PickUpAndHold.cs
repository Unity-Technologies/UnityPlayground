 using UnityEngine;
 
 public class PickUpAndHold : MonoBehaviour
 {
     // An object need to closer than that distance to be picked up.
     public float pickUpDistance = 1f;
     
     private Transform carriedObject = null;
     private int pickupLayer = 0;
 
     private void Update()
     {
         if( Input.GetButton( "Pickup" ) ) // Define it in the input manager
         {
             if( carriedObject != null )
			 {
				// Do Nothing
			 }
             else // Nothing in hand, we check if something is around and pick it up.
                 PickUp();
         }

		 if (Input.GetButton("Drop"))
		 {
			 if( carriedObject != null )
			 {
				 // We're holding something already, we drop
                 Drop();
			 }
			 else
			 {
				 // Do nothing
			 }
		 }
     }
 
     private void Drop()
     {
		 carriedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
         carriedObject.parent = null; // Unparenting
         carriedObject = null; // Hands are free again
     }
 
     private void PickUp()
     {
		 Debug.Log("pickup");
		 pickupLayer = 1 << LayerMask.NameToLayer( "Pickup" );
		 Debug.Log(pickupLayer);
         // Collect every pickups around. Make sure they have a collider and the layer Pickup
         Collider2D[] pickups = Physics2D.OverlapCircleAll(Utils.GetVector2FromVector3(transform.position), pickUpDistance, pickupLayer );
 
		Debug.Log(pickups[0].name);
         // Find the closest
         float dist = Mathf.Infinity;
         for( int i = 0; i < pickups.Length; i++ )
         {
             float newDist = (transform.position - pickups[i].transform.position).sqrMagnitude;
             if( newDist  < dist )
             {
                 carriedObject = pickups[i].transform;
                 dist = newDist;
				 Debug.Log(carriedObject);
             }
         }
     
         if( carriedObject != null ) // Check if we found something
         {
             // Set the box in front of character
             carriedObject.parent = gameObject.transform;
			 // Set to Kinematic so it will move with the Player
			 carriedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
         }
     }
 }