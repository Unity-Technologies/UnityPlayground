using UnityEngine;

namespace Playground.BaseClasses
{
    public abstract class Action : MonoBehaviour
    {
        public virtual bool ExecuteAction(GameObject other)
        {
            // The return value indicates if the action has been successful
            // Some actions always return true
            return true;
        }
    }
}