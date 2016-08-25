using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class ConditionCollision : ConditionBase
{
	[Space(20)]
	public string filterTag = "Player";
	
	// This function will be called when something touches the trigger collider
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.CompareTag(filterTag))
		{
			ExecuteAllActions();
		}
	}
}
