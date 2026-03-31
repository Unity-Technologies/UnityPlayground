using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Playground.UserInterface
{
    [AddComponentMenu("")]
    public class BalloonScript : MonoBehaviour
    {
        public Text dialogueText, buttonText;

        // Action fired when the time is up, or when the right button has been pressed (depends on isUsingButton)
        public UnityAction BalloonDestroyed;

        private Key _buttonUsed;
        private float _duration;
        private bool _isUsingButton;
        private RectTransform _rectTransform;
        private float _startTime;
        private Transform _targetObj;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            if (_targetObj != null) FollowTarget();

            if (_isUsingButton)
            {
                if (Keyboard.current[_buttonUsed].wasPressedThisFrame) Destroy(gameObject);
            }
            else
            {
                if (Time.time >= _startTime + _duration) Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            BalloonDestroyed();
        }

        public void Setup(string dialogueString, bool isUsingButton, Key buttonUsed, float time,
            Color backgroundC, Color textC, Transform targetObj = null)
        {
            _isUsingButton = isUsingButton;
            _buttonUsed = buttonUsed;
            _targetObj = targetObj;
            _duration = time;

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
                _startTime = Time.time;
            }

            // Create just above the target, or at the centre
            if (targetObj == null)
            {
                _rectTransform.pivot = new Vector2(0.5f, 0.5f); // Pivot is in the centre
                _rectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, Vector3.zero);
            }
            else
            {
                _rectTransform.pivot = new Vector2(0.5f, 0f); // Pivot is at the bottom
                FollowTarget();
            }
        }

        private void FollowTarget()
        {
            Vector3 topBoundary = _targetObj.position;
            SpriteRenderer sr = _targetObj.GetComponent<SpriteRenderer>();
            if (sr != null)
                topBoundary.y += sr.bounds.size.y;
            else
                // The object is invisible in some way (has no SpriteRenderer)
                topBoundary.y = _targetObj.position.y;
            
            _rectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, topBoundary);
        }
    }
}