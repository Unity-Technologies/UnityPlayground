using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class ConditionEnterArea : ConditionBase
{
	
	// This function will be called when something enters the trigger collider
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if(otherCollider.CompareTag(filterTag)
			|| !filterByTag)
		{
			ExecuteAllActions(otherCollider.gameObject);
		}
	}
}
