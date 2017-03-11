using UnityEngine;
using System.Collections;
using System;

//interface that all Actions implement
//note the interface is called Action and not IAction to make it more friendly in the editor
public class Action : MonoBehaviour
{
	public virtual bool ExecuteAction(GameObject other)
	{
		//the return value indicates if the action has been successful
		//some actions always return true
		return true;
	}
}
