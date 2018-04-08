using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Resource")]
[RequireComponent(typeof(PolygonCollider2D), typeof(SpriteRenderer))]
public class ResourceAttribute : MonoBehaviour
{
	//this is actually more a name/identifier than a type, but from the kids' perspective it makes sense that they are inputting the "type of resource"
	public string resourceType = "Coal";
	public int amount = 1;

	private UIScript userInterface;



	// Start is called at the beginning
	private void Start()
	{
		// Find the UI in the scene and store a reference for later use
		userInterface = GameObject.FindObjectOfType<UIScript>();
	}




	private void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// is the other object a player?
		if(otherCollider.CompareTag("Player")
			|| otherCollider.CompareTag("Player2"))
		{
			if(userInterface != null)
			{
				userInterface.AddResource(resourceType, amount, GetComponent<SpriteRenderer>().sprite);
			}

			Destroy(gameObject);
		}
	}
}
