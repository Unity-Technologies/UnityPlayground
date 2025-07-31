using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Modify Health")]
[HelpURL("https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-1/#ModifyHealthAttribute%EF%BC%88HP_%E5%A2%97%E6%B8%9B%EF%BC%89")]
public class ModifyHealthAttribute : MonoBehaviour
{

    public bool destroyWhenActivated = false;
    public int healthChange = -1;

    //This will create a dialog window asking for which dialog to add
    private void Reset()
    {
        Utils.Collider2DDialogWindow(this.gameObject, true);
    }

    // This function gets called everytime this object collides with another
    private void OnCollisionEnter2D(Collision2D collisionData)
    {
        OnTriggerEnter2D(collisionData.collider);
    }

    private void OnTriggerEnter2D(Collider2D colliderData)
    {
        HealthSystemAttribute healthScript = colliderData.gameObject.GetComponent<HealthSystemAttribute>();
        if (healthScript != null)
        {
            // subtract health from the player
            healthScript.ModifyHealth(healthChange);

            if (destroyWhenActivated)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
