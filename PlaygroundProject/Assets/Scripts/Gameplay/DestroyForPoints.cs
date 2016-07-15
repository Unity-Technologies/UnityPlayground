using UnityEngine;
using System.Collections;

public class DestroyForPoints : MonoBehaviour
{
	private UIScript ui;
	private int playerNumber;


	// Start is called at the beginning of the game
	private void Start()
	{
		// Find the UI in the scene and store a reference for later use
		ui = GameObject.FindObjectOfType<UIScript>();

		// Set the player number based on the GameObject tag
		playerNumber = (gameObject.CompareTag("Player")) ? 0 : 1;
	}
	
	
	// This function gets called when the object is destroyed
	private void OnDestroy()
	{
		if(ui != null)
		{
			// award one point
			ui.AddOnePoint(playerNumber);
		}
	}
}
