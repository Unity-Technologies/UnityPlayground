using Playground.BaseClasses;
using Playground.UserInterface;
using UnityEngine;

namespace Playground.Conditions.Actions
{
    [AddComponentMenu("Playground/Actions/Consume Resource")]
    public class ConsumeResourceAction : Action
    {
        [Header("Resource")] public int checkFor;

        public int amountNeeded = 1;

        private UIScript userInterface;


        private void Start()
        {
            // Find the UI in the scene and store a reference for later use
            userInterface = FindAnyObjectByType<UIScript>();
        }


        public override bool ExecuteAction(GameObject dataObject)
        {
            if (userInterface != null)
            {
                bool hasEnoughResource = userInterface.CheckIfHasResources(checkFor, amountNeeded);

                if (hasEnoughResource)
                    // Consume the resource and update the UI
                    userInterface.ConsumeResource(checkFor, amountNeeded);

                return hasEnoughResource;
            }

            Debug.LogWarning("User Interface prefab has not been found in the scene. The action can't execute!");
            return false;
        }
    }
}