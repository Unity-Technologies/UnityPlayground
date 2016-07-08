using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class TriggerExitArea : TriggerArea
{
	[Space(20)]
	public UnityEvent triggerExited;


	// This function will be called when something exits the trigger
	void OnTriggerExit2D(Collider2D otherCollider)
	{
		if(CheckIfPlayerOnly(otherCollider))
		{
			triggerExited.Invoke();
		}
	}
}
