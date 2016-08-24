using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class TriggerStayInArea : TriggerBase
{
	// the amount of times (in seconds) that this trigger will call OnTriggerStay
	// i.e. if it's 1, it means that OnTriggerStay will be called every second
	// i.e. if it's 4, it means that it will be called every 4 seconds
	// ... and so on...
	public float frequency = 1f;

	[Space(20)]
	public string filterTag = "Player";

	private float lastTimeTriggerStayCalled;


	// This function will be called at the beginning
	void Start()
	{
		lastTimeTriggerStayCalled = -frequency;
	}
	
	// This will be called EVERY FRAME when something stays inside the trigger
	void OnTriggerStay2D(Collider2D otherCollider)
	{
		if(otherCollider.CompareTag(filterTag)
		   && Time.time >= lastTimeTriggerStayCalled + frequency)
		{
			lastTimeTriggerStayCalled = Time.time;
			ExecuteAllActions();
		}
	}
}
