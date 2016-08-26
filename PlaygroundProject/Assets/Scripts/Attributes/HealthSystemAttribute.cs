using UnityEngine;
using System.Collections;

public class HealthSystemAttribute : MonoBehaviour
{
	public int health = 3;

	private UIScript ui;

	// Will be set to 0 or 1 depending on how the GameObject is tagged
	// it's -1 if the object is not a player
	private int playerNumber;



	private void Start()
	{
		// Find the UI in the scene and store a reference for later use
		ui = GameObject.FindObjectOfType<UIScript>();

		// Set the player number based on the GameObject tag
		switch(gameObject.tag)
		{
			case "Player":
				playerNumber = 0;
				break;
			case "Player2":
				playerNumber = 1;
				break;
			default:
				playerNumber = -1;
				break;
		}

		// Notify the UI so it will show the right initial amount
		if(ui != null
			&& playerNumber != -1)
		{
			ui.SetHealth(health, playerNumber);
		}
	}


	// changes the energy from the player
	// also notifies the UI (if present)
	public void ModifyHealth(int amount)
	{
		health += amount;

		// Notify the UI so it will change the number in the corner
		if(ui != null
			&& playerNumber != -1)
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
