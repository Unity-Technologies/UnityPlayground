using Playground.BaseClasses;
using Playground.UserInterface;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Playground.Conditions.Actions
{
    [AddComponentMenu("Playground/Actions/Dialogue Balloon")]
    public class DialogueBalloonAction : Action
    {
        public enum DisappearMode
        {
            Time = 0,
            ButtonPress = 1
        }

        [Header("Contents")] public string textToDisplay = "Hey!";

        public Color backgroundColor = new Color32(113, 132, 146, 255);
        public Color textColor = Color.white;

        [Header("Options")] public Transform targetObject;

        public DisappearMode disappearMode = DisappearMode.ButtonPress;
        public float timeToDisappear = 2f;
        public Key keyToPress = Key.Enter;

        [Header("Continue dialogue")] public DialogueBalloonAction followingText;

        // The balloon currently on screen. It's also null if the balloon was destroyed some other way (e.g. with the UI)
        private BalloonScript b;


        public override bool ExecuteAction(GameObject other)
        {
            // Don't show a new balloon while this one is still up
            if (b != null) return false;

            DialogueSystem d = FindAnyObjectByType<DialogueSystem>();
            if (d == null)
            {
                // Dialogue System is not in the scene
                Debug.LogWarning("You need a UI in the scene to display dialogue!");
                return false;
            }

            // Dialogue System is found
            b = d.CreateBalloon(textToDisplay, disappearMode == DisappearMode.ButtonPress, keyToPress,
                timeToDisappear, backgroundColor, textColor, targetObject);
            b.BalloonDestroyed += OnBalloonDestroyed;
            return true;
        }


        private void OnBalloonDestroyed()
        {
            b.BalloonDestroyed -= OnBalloonDestroyed;
            b = null;

            // This Action might have been destroyed while the balloon was up
            if (this == null) return;

            if (followingText != null) followingText.ExecuteAction(gameObject);
        }
    }
}