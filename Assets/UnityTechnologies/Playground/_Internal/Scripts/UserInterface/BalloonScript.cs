using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Playground.UserInterface
{
    [AddComponentMenu("")]
    public class BalloonScript : MonoBehaviour
    {
        public Text dialogueText, buttonText;

        public UnityAction
            BalloonDestroyed; // Action fired when the time is up, or when the right button has been pressed (depends on isUsingButton)

        private KeyCode buttonUsed;
        private float duration;
        private bool isUsingButton;

        private RectTransform rectTransform;

        private float startTime;
        private Transform targetObj;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            if (targetObj != null) FollowTarget();

            if (isUsingButton)
            {
                if (Input.GetKeyUp(buttonUsed)) Destroy(gameObject);
            }
            else
            {
                if (Time.time >= startTime + duration) Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            BalloonDestroyed();
        }

        public void Setup(string dialogueString, bool _isUsingButton, KeyCode _buttonUsed, float _time,
            Color backgroundC, Color textC, Transform _targetObj = null)
        {
            isUsingButton = _isUsingButton;
            buttonUsed = _buttonUsed;
            targetObj = _targetObj;
            duration = _time;

            // Background setup
            GetComponent<Image>().color = backgroundC;

            // Main dialogue text and colour
            dialogueText.text = dialogueString;
            dialogueText.color = textC;

            // Button text setup
            if (isUsingButton)
            {
                buttonText.text = "press " + buttonUsed;
                buttonText.color = textC;
            }
            else
            {
                buttonText.gameObject.SetActive(false);
                startTime = Time.time;
            }

            //create just above the target, or at the centre
            if (targetObj == null)
            {
                rectTransform.pivot = new Vector2(0.5f, 0.5f); // Pivot is in the centre
                rectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, Vector3.zero);
            }
            else
            {
                rectTransform.pivot = new Vector2(0.5f, 0f); // Pivot is at the bottom
                FollowTarget();
            }
        }

        private void FollowTarget()
        {
            Vector3 topBoundary = targetObj.position;
            SpriteRenderer sr = targetObj.GetComponent<SpriteRenderer>();
            if (sr != null)
                topBoundary.y += sr.bounds.size.y;
            else
                // The object is invisible in some way (has no SpriteRenderer)
                topBoundary.y = targetObj.position.y;
            rectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, topBoundary);
        }
    }
}