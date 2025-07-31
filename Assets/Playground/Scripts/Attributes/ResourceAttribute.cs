using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Resource")]
[HelpURL("https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-1/#ResourceAttribute%EF%BC%88%E3%82%A2%E3%82%A4%E3%83%86%E3%83%A0%E3%82%92%E6%8C%81%E3%81%A4%EF%BC%89")]
[RequireComponent(typeof(SpriteRenderer))]
public class ResourceAttribute : MonoBehaviour
{
    //the "type of resource", this index point to the array in the centralised InventoryResources ScriptableObject
    //リソースの種類を表す。InventoryResources アセットのインデックス番号が入る。
    public int resourceIndex = 0;
    public int amount = 1;

    private UIScript userInterface;

    // Start is called at the beginning
    private void Start()
    {
        // Find the UI in the scene and store a reference for later use
        userInterface = GameObject.FindObjectOfType<UIScript>();
    }

    //This will create a dialog window asking for which dialog to add
    private void Reset()
    {
        Utils.Collider2DDialogWindow(this.gameObject, true);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // is the other object a player?
        if (otherCollider.CompareTag("Player")
            || otherCollider.CompareTag("Player2"))
        {
            if (userInterface != null)
            {
                userInterface.AddResource(resourceIndex, amount, GetComponent<SpriteRenderer>().sprite);
            }
            else
            {
                //Debug.LogWarning("User Interface is not in the scene, so the resource cannot be displayed and put in the inventory.");
                Debug.LogWarning("シーンに UserInterface がないので、リソースを画面に表示したりインベントリに追加することができません。");
            }

            Destroy(gameObject);
        }
    }
}
