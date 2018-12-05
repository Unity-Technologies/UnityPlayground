using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Collectable")]
public class CollectableAttribute : MonoBehaviour
{
	private UIScript userInterface;


	private void Start()
	{
		// Find the UI in the scene and store a reference for later use
		userInterface = GameObject.FindObjectOfType<UIScript>();
	}


	//This will create a dialog window asking for which dialog to add
	private void Reset()
	{
		Utils.Collider2DDialogWindow(this.gameObject);
	}


	// This function gets called everytime this object collides with another
	private void OnTriggerEnter2D(Collider2D otherCollider)
	{
		string playerTag = otherCollider.gameObject.tag;

		// is the other object a player?
		if(playerTag == "Player" || playerTag == "Player2")
		{
			if(userInterface != null)
			{
				// add one point
				int playerId = (playerTag == "Player") ? 0 : 1;
				userInterface.AddOnePoint(playerId);
			}

			// then destroy this object
			Destroy(gameObject);
		}
	}
}
