using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Playground.BaseClasses
{
    public abstract class ConditionBase : MonoBehaviour
    {
        // Action items can be connected to GameplayAction scripts, and execute their one action (the method ExecuteAction implemented in each child class)
        [SerializeField] public List<Action> actions = new();

        // Custom actions are more complicated to setup but more powerful, and appear only if useCustomActions is enabled
        public bool useCustomActions;
        public UnityEvent customActions;

        // To perform the actions only once
        public bool happenOnlyOnce;

        public bool filterByTag;
        public string filterTag = "Player";
        private bool alreadyHappened;

        //dataObject is usually the other object in the collision
        public void ExecuteAllActions(GameObject dataObject)
        {
            // First check if the action has already been executed
            if (happenOnlyOnce && alreadyHappened)
                return;

            // First execute the simple GameplayActions, if present
            foreach (Action ga in actions)
                if (ga != null)
                {
                    bool actionResult = ga.ExecuteAction(dataObject);
                    if (!actionResult)
                    {
                        Debug.Log($"An action failed ({ga.GetType().Name}) and interrupted the chain of Actions");
                        return;
                    }
                }

            // Execute the custom actions, if present and enabled
            if (useCustomActions) customActions.Invoke();

            alreadyHappened = true; // Will prevent re-executing the actions if happenOnlyOnce is true
        }
    }
}