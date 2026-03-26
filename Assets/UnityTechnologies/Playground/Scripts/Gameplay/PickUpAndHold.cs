using UnityEngine;
using UnityEngine.InputSystem;

namespace Playground.Gameplay
{
    [AddComponentMenu("Playground/Gameplay/Pick Up And Hold")]
    public class PickUpAndHold : MonoBehaviour
    {
        // Pickup key and drop key could be the same
        public Key pickupKey = Key.B;
        public Key dropKey = Key.B;

        public float pickUpDistance = 2f; // An object need to closer than that distance to be picked up.

        private Transform carriedObject;

        private void Update()
        {
            bool justPickedUpSomething = false;

            // Nothing in hand, we check if something is around and pick it up.
            if (Keyboard.current[pickupKey].wasPressedThisFrame
                && carriedObject == null)
                justPickedUpSomething = PickUp();
            
            // We're holding something already, we drop
            if (Keyboard.current[dropKey].wasPressedThisFrame
                && carriedObject != null
                && !justPickedUpSomething)
                Drop();
        }

        public void Drop()
        {
            Rigidbody2D rb2d = carriedObject.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                rb2d.bodyType = RigidbodyType2D.Dynamic;
                rb2d.linearVelocity = Vector2.zero;
            }

            carriedObject.parent = null;
            carriedObject = null;
        }

        public bool PickUp()
        {
            // Collect every Pickup around
            GameObject[] pickups = GameObject.FindGameObjectsWithTag("Pickup");

            // Find the closest
            float dist = pickUpDistance;
            for (int i = 0; i < pickups.Length; i++)
            {
                float newDist = (transform.position - pickups[i].transform.position).sqrMagnitude;
                if (newDist < dist)
                {
                    carriedObject = pickups[i].transform;
                    dist = newDist;
                }
            }

            // Check if we found something
            if (carriedObject != null)
            {
                // Check if another player had it, in this case, steal it
                Transform pickupParent = carriedObject.parent;
                if (pickupParent != null)
                {
                    PickUpAndHold pickupScript = pickupParent.GetComponent<PickUpAndHold>();
                    if (pickupScript != null) pickupScript.Drop();
                }

                carriedObject.parent = gameObject.transform;
                Rigidbody2D rb2d = carriedObject.GetComponent<Rigidbody2D>();
                if (rb2d != null) rb2d.bodyType = RigidbodyType2D.Kinematic;
                return true;
            }

            return false;
        }
    }
}