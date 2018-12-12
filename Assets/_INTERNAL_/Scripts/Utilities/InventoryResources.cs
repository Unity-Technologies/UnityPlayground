using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventoryResources : ScriptableObject
{
	[SerializeField]
	public List<string> resourcesTypes;

	public string[] GetResourceTypes()
	{
		//Just an annoying loop to switch the List<string> into an array of strings
		string[] resourceTypesArray = new string[resourcesTypes.Count];
		for(int i=0; i<resourcesTypes.Count; i++)
		{
			resourceTypesArray[i] = resourcesTypes[i];
		}
		
		return resourceTypesArray;
	}
}