using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class TriggerCollision : TriggerArea
{
	[Space(20)]
	public UnityEvent colliderTouched;
	
	
	// This function will be called when something touches the trigger
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(CheckIfPlayerOnly(collision.collider))
		{
			colliderTouched.Invoke();
		}
	}
}
