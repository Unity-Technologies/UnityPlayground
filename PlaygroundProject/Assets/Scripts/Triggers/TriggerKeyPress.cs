using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class TriggerKeyPress : TriggerBase
{
	public KeyCode keyToPress;



	private void Update()
	{
		if(Input.GetKeyDown(keyToPress))
		{
			ExecuteAllActions();
		}
	}
}