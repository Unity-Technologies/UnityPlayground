using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class ConsumeResourceAction : ConditionBase, IGameplayAction
{
	[Header("Resource")]

	public string checkFor = "Coal";
	public int amountNeeded = 1;


	//reference to the UI
	private UIScript userInterface;



	// Start is called at the beginning
	private void Start()
	{
		// Find the UI in the scene and store a reference for later use
		userInterface = GameObject.FindObjectOfType<UIScript>();
	}



	public void ExecuteAction(GameObject dataObject)
	{
		if(userInterface.CheckIfHasResources(checkFor, amountNeeded))
		{
			//consume the resource and update the UI
			userInterface.ConsumeResource(checkFor, amountNeeded);

			ExecuteAllActions(dataObject);
		}
	}



}
