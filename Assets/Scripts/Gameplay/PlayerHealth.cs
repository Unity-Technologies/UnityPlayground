using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int health = 3;

	private UIScript ui;

	private void Start()
	{
		ui = GameObject.FindObjectOfType<UIScript>();
		if(ui != null){ ui.SetHealth(health); }
	}


	// Subtracts energy from the player
	// also notifies the UI (if present)
	public void SubHealth(int amount)
	{
		health -= amount;
		if(ui != null){ ui.SubHealth(amount); }

		//DEAD
		if(health <= 0)
		{
			Destroy(gameObject);
		}
	}
}
