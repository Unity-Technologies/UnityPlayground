using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[AddComponentMenu("Playground/Actions/Consume Resource")]
public class ConsumeResourceAction : Action
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



	public override bool ExecuteAction(GameObject dataObject)
	{
		bool hasEnoughResource = userInterface.CheckIfHasResources(checkFor, amountNeeded);

		if(hasEnoughResource)
		{
			//consume the resource and update the UI
			userInterface.ConsumeResource(checkFor, amountNeeded);
		}

		return hasEnoughResource;
	}



}
