using UnityEngine;
using System.Collections;

public class CreateObjectAction : Action
{
	public GameObject prefabToCreate;
	public Vector3 newPosition;



	// Moves the gameObject instantly to a custom position
	public override bool ExecuteAction(GameObject dataObject)
	{
		if(prefabToCreate != null)
		{
			//create the new object by copying the prefab
			GameObject newObject = Instantiate<GameObject>(prefabToCreate);


			//let's place it in the desired position!
			newObject.transform.position = newPosition;

			return true;
		}
		else
		{
			return false;
		}
	}
}
