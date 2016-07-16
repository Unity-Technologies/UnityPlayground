using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int health = 3;

	private UIScript ui;

	// Will be set to 0 or 1 depending on how the GameObject is tagged
	private int playerNumber;



	private void Start()
	{
		// Find the UI in the scene and store a reference for later use
		ui = GameObject.FindObjectOfType<UIScript>();

		// Set the player number based on the GameObject tag
		playerNumber = (gameObject.CompareTag("Player")) ? 0 : 1;

		// Notify the UI so it will show the right initial amount
		if(ui != null)
		{
			ui.SetHealth(health, playerNumber);
		}
	}


	// Subtracts energy from the player
	// also notifies the UI (if present)
	public void SubHealth(int amount)
	{
		health -= amount;

		// Notify the UI so it will change the number in the corner
		if(ui != null)
		{
			ui.SubHealth(amount, playerNumber);
		}

		//DEAD
		if(health <= 0)
		{
			Destroy(gameObject);
		}
	}
}
