using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class TriggerCollision : TriggerBase
{
	[Space(20)]
	public string filterTag = "Player";
	
	// This function will be called when something touches the trigger
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.CompareTag(filterTag))
		{
			ExecuteAllActions();
		}
	}
}
