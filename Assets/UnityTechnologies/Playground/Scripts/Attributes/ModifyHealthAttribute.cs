using Playground.Utilities;
using UnityEngine;

namespace Playground.Attributes
{
    [AddComponentMenu("Playground/Attributes/Modify Health")]
    public class ModifyHealthAttribute : MonoBehaviour
    {
        public bool destroyWhenActivated;
        public int healthChange = -1;

        //This will create a dialog window asking for which dialog to add
        private void Reset()
        {
            Utils.Collider2DDialogWindow(gameObject, true);
        }

        // This function gets called everytime this object collides with another
        private void OnCollisionEnter2D(Collision2D collisionData)
        {
            OnTriggerEnter2D(collisionData.collider);
        }

        private void OnTriggerEnter2D(Collider2D colliderData)
        {
            if (colliderData.TryGetComponent(out HealthSystemAttribute healthScript))
            {
                // subtract health from the player
                healthScript.ModifyHealth(healthChange);

                if (destroyWhenActivated) Destroy(gameObject);
            }
        }
    }
}