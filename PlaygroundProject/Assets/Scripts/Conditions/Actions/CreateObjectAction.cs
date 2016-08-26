using UnityEngine;
using System.Collections;

public class CreateObjectAction : MonoBehaviour, IGameplayAction
{
	public GameObject prefabToCreate;
	public Vector3 newPosition;



	// Moves the gameObject instantly to a custom position
	public void ExecuteAction(GameObject dataObject)
	{
		if(prefabToCreate != null)
		{
			//create the new object by copying the prefab
			GameObject newObject = Instantiate<GameObject>(prefabToCreate);


			//let's place it in the desired position!
			newObject.transform.position = newPosition;
		}
	}
}
