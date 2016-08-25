using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class ConditionExitArea : ConditionBase
{
	[Space(20)]
	public string filterTag = "Player";


	// This function will be called when something exits the trigger collider
	void OnTriggerExit2D(Collider2D otherCollider)
	{
		if(otherCollider.CompareTag(filterTag))
		{
			ExecuteAllActions();
		}
	}
}
