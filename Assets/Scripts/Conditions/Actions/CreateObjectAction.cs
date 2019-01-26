using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Actions/Create Object")]
public class CreateObjectAction : Action
{
	public GameObject prefabToCreate;
	public Vector2 newPosition;
	public bool relativeToThisObject;
	public bool afterDelay;
	public int secondsToWait = 1;
		
	// Creates a new GameObject
	public override bool ExecuteAction(GameObject dataObject)
	{
		if (prefabToCreate != null)
		{
			if (afterDelay)
			{
				StartCoroutine(SpawnAfterDelay());
			}
			else
			{
				SpawnObject();
			}
			
			return true;
		}

		Debug.LogWarning("There is no Prefab assigned to this CreateObjectAction, so a new object can't be created.");
		return false;
	}

	//Spawn the specified prefab in the scene
	private void SpawnObject()
	{
		//create the new object by copying the prefab
		GameObject newObject = Instantiate(prefabToCreate);

		//is the position relative or absolute?
		Vector2 finalPosition = newPosition;
		if (relativeToThisObject)
		{
			finalPosition = (Vector2) transform.position + newPosition;
		}

		//let's place it in the desired position!
		newObject.transform.position = finalPosition;
	}

	private IEnumerator SpawnAfterDelay()
	{
		//Wait for specified time
		yield return new WaitForSecondsRealtime(secondsToWait);
		
		//Spawn the object
		SpawnObject();
	}
}
