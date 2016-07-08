using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class Collectable : MonoBehaviour
{
	private UIScript ui;

	private void Start()
	{
		ui = GameObject.FindObjectOfType<UIScript>();
	}

	
	// This function gets called everytime this object collides with another
	private void OnCollisionEnter2D(Collision2D coll)
	{
		// is the other object a player?
		if(coll.gameObject.CompareTag("Player"))
		{
			if(ui != null)
			{
				// add one point
				ui.AddOnePoint();
			}

			// then destroy this object
			Destroy(gameObject);
		}
	}
}
