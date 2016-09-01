using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class ConditionExitArea : ConditionBase
{

	// This function will be called when something exits the trigger collider
	void OnTriggerExit2D(Collider2D otherCollider)
	{
		if(otherCollider.CompareTag(filterTag)
			|| !filterByTag)
		{
			ExecuteAllActions(otherCollider.gameObject);
		}
	}
}
