using UnityEngine;
using System.Collections;

public class DestroyForPointsAttribute : MonoBehaviour
{
	private UIScript userInterface;


	// Start is called at the beginning of the game
	private void Start()
	{
		// Find the UI in the scene and store a reference for later use
		userInterface = GameObject.FindObjectOfType<UIScript>();
	}
	
	
	// This function gets called everytime this object collides with another
	private void OnCollisionEnter2D(Collision2D collisionData)
	{
		// is the other object a Bullet?
		if(collisionData.gameObject.CompareTag("Bullet"))
		{
			if(userInterface != null)
			{
				// add one point
				BulletAttribute b = collisionData.gameObject.GetComponent<BulletAttribute>();
				if(b != null)
				{
					userInterface.AddOnePoint(b.playerId);
				}
			}

			// then destroy this object
			Destroy(gameObject);
		}
	}
}
