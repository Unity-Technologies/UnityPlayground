using UnityEngine;

namespace Playground.Scripts.BaseClasses
{
	public abstract class Action : MonoBehaviour
	{
		public virtual bool ExecuteAction(GameObject other)
		{
			//the return value indicates if the action has been successful
			//some actions always return true
			return true;
		}
	}
}
