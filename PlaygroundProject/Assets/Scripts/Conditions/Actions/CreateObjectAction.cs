using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Actions/Create Object")]
public class CreateObjectAction : Action
{
	public GameObject prefabToCreate;
	public Vector2 newPosition;
	public bool relative;


	void Update ()
	{
		if (relative)
		{
			newPosition = transform.localPosition;
		}
	}
		
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
