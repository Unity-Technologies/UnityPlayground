using UnityEngine;
using System.Collections;
using System;

//parent class to all Actions
public interface IGameplayAction
{
	void ExecuteAction(GameObject other);
}
