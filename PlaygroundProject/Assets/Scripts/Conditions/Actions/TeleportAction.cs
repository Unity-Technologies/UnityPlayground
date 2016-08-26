using UnityEngine;
using System.Collections;

public class TeleportAction : MonoBehaviour, IGameplayAction
{
	public GameObject objectToMove;
	public Vector3 newPosition;



	// Moves the gameObject instantly to a custom position
	public void ExecuteAction(GameObject dataObject)
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
