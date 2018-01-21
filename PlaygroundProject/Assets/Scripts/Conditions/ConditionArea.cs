using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[AddComponentMenu("Playground/Conditions/Area")]
[RequireComponent(typeof(BoxCollider2D))]
public class ConditionArea : ConditionBase
{
	// the amount of times (in seconds) that this Condition will call OnTriggerStay
	// i.e. if it's 1, it means that OnTriggerStay will be called every second
	// i.e. if it's 4, it means that it will be called every 4 seconds
	// ... and so on...
	public float frequency = 1f;
	//not used in case of ColliderEventTypes.Enter and ColliderEventTypes.Exit


	//the type of event to check for
	[Header("Type of Event")]
	public ColliderEventTypes eventType = ColliderEventTypes.Enter;



	private float lastTimeTriggerStayCalled;


	// This function will be called at the beginning
	void Start()
	{
		lastTimeTriggerStayCalled = -frequency;
	}
	


	//this function is called every time another collider enters this trigger
	private void OnTriggerEnter2D(Collider2D otherCollider)
	{
		//is this the type of event we need?
		if(eventType == ColliderEventTypes.Enter)
		{

			//check for the tag of the object which entered the area, if necessary
			if(otherCollider.CompareTag(filterTag)
				|| !filterByTag)
			{
				ExecuteAllActions(otherCollider.gameObject);
			}
		}
	}



	// This will be called EVERY FRAME when something stays inside the trigger collider
	void OnTriggerStay2D(Collider2D otherCollider)
	{
		//is this the type of event we need?
		if(eventType == ColliderEventTypes.StayInside
			&& Time.time >= lastTimeTriggerStayCalled + frequency) //check also the frequency
		{
			
			//check for the tag of the object which entered the area, if necessary
			if(otherCollider.CompareTag(filterTag)
				|| !filterByTag)
			{
				ExecuteAllActions(otherCollider.gameObject);
				lastTimeTriggerStayCalled = Time.time;
			}
		}
	}



	//this function is called every time another collider exits this trigger
	private void OnTriggerExit2D(Collider2D otherCollider)
	{
		//is this the type of event we need?
		if(eventType == ColliderEventTypes.Exit)
		{

			//check for the tag of the object which entered the area, if necessary
			if(otherCollider.CompareTag(filterTag)
				|| !filterByTag)
			{
				ExecuteAllActions(otherCollider.gameObject);
			}
		}
	}



	public enum ColliderEventTypes
	{
		Enter,
		Exit,
		StayInside
	}



}
