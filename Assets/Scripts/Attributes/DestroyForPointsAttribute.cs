using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Destroy For Points")]
public class DestroyForPointsAttribute : MonoBehaviour
{
	public int pointsWorth = 1;

	private UIScript userInterface;

	private void Start()
	{
		// Find the UI in the scene and store a reference for later use
		userInterface = GameObject.FindObjectOfType<UIScript>();
	}
	

	//This will create a dialog window asking for which dialog to add
	private void Reset()
	{
		Utils.Collider2DDialogWindow(this.gameObject, false);
	}
	
	//duplication of the following function to accomodate both trigger and non-trigger Colliders
	private void OnCollisionEnter2D(Collision2D collisionData)
	{
		OnTriggerEnter2D(collisionData.collider);
	}

	// This function gets called everytime this object collides with another trigger
	private void OnTriggerEnter2D(Collider2D collisionData)
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
					userInterface.AddPoints(b.playerId, pointsWorth);
				}
				else
				{
					Debug.Log("Use a BulletAttribute on one of the objects involved in the collision if you want one of the players to receive points for destroying the target.");
				}
			}
			else
			{
				Debug.Log("There is no UI in the scene, hence points can't be displayed.");
			}

			// then destroy this object
			Destroy(gameObject);
		}
	}
}
