using Playground.Scripts.BaseClasses;
using UnityEngine;

namespace Playground.Conditions
{
	[AddComponentMenu("Playground/Conditions/Condition Repeat")]
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
}