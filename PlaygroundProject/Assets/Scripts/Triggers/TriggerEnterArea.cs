using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class TriggerEnterArea : TriggerArea
{
	[Space(20)]
	public UnityEvent triggerEntered;

	public string filterTag = "Player";


	// This function will be called when something enters the trigger
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if(otherCollider.CompareTag(filterTag))
		{
			triggerEntered.Invoke();
		}
	}
}
