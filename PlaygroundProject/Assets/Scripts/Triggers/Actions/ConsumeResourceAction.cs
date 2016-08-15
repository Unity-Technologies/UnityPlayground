using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class ConsumeResourceAction : MonoBehaviour
{
	[Header("Resource needed")]

	public string resourceToCheck = "Coal";
	public int amountNeeded = 1;

	[Header("Action")]
	public UnityEvent onResourceConsumed;


	//reference to the UI
	private UIScript userInterface;



	// Start is called at the beginning
	private void Start()
	{
		// Find the UI in the scene and store a reference for later use
		userInterface = GameObject.FindObjectOfType<UIScript>();
	}



	public void ConsumeResource()
	{
		if(userInterface.CheckIfHasResources(resourceToCheck, amountNeeded))
		{
			//consume the resource and update the UI
			userInterface.ConsumeResource(resourceToCheck, amountNeeded);

			//invoke the connected action
			onResourceConsumed.Invoke();
		}
	}
}
