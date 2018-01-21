using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Playground/Conditions/Repeat")]
public class ConditionRepeat : ConditionBase
{
	public float initialDelay = 0f;
	public float frequency = 1f;

	private float timeLastEventFired;


	private void Start()
	{
		timeLastEventFired = initialDelay - frequency;
	}


	private void Update()
	{
		if(Time.time >= timeLastEventFired + frequency)
		{
			ExecuteAllActions(null);
			timeLastEventFired = Time.time;
		}
	}
}