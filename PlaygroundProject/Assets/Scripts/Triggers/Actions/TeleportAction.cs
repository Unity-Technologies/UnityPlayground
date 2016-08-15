using UnityEngine;
using System.Collections;

public class TeleportAction : MonoBehaviour
{
	public GameObject objectToMove;
	public Vector3 newPosition;




	// Moves the gameObject instantly to a custom position
	public void TeleportObject()
	{
		if(objectToMove != null)
		{
			//moves the specified object
			objectToMove.transform.position = newPosition; 
		}
		else
		{
			//moves this object
			transform.position = newPosition;
		}
	}
}
