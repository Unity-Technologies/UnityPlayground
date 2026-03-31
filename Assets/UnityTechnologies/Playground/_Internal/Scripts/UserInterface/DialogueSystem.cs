using UnityEngine;
using UnityEngine.InputSystem;

namespace Playground.UserInterface
{
    [AddComponentMenu("")]
    public class DialogueSystem : MonoBehaviour
    {
        public GameObject balloonPrefab;
        //private static List<DialogueBalloonAction> balloons = new List<DialogueBalloonAction>();

        public BalloonScript CreateBalloon(string dialogueString, bool usingButton, Key button,
            float timeToDisappear, Color backgroundC, Color textC, Transform targetObj = null)
        {
            BalloonScript b = Instantiate(balloonPrefab).GetComponent<BalloonScript>();
            b.transform.SetParent(transform, false);
            b.Setup(dialogueString, usingButton, button, timeToDisappear, backgroundC, textC, targetObj);

            return b;
        }
    }
}