using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
public class Resource : MonoBehaviour
{
	//this is actually more a name/identifier than a type, but from the kids' perspective it makes sense that they are inputting the "type of resource"
	public string resourceType;
	public int amount;

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
		if(otherCollider.CompareTag("Player"))
		{
			if(userInterface != null)
			{
				userInterface.AddResource(resourceType, amount, GetComponent<SpriteRenderer>().sprite);
			}

			Destroy(gameObject);
		}
	}
}
