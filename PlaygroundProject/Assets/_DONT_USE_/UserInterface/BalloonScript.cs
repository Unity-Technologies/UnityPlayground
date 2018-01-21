using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

[AddComponentMenu("")]
public class BalloonScript : MonoBehaviour
{
	public Text dialogueText, buttonText;
	public UnityAction BalloonDestroyed; //action fired when the time is up, or when the right button has been pressed (depends on isUsingButton)

	private RectTransform rectTransform;
	private bool isUsingButton;
	private KeyCode buttonUsed;
	private Transform targetObj;

	private float startTime;
	private float duration;

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
	}

	public void Setup(string dialogueString, bool _isUsingButton, KeyCode _buttonUsed, float _time, Color backgroundC, Color textC, Transform _targetObj = null)
	{
		isUsingButton = _isUsingButton;
		buttonUsed = _buttonUsed;
		targetObj = _targetObj;
		duration = _time;

		//background setup
		GetComponent<Image>().color = backgroundC;

		//main dialogue text and colour
		dialogueText.text = dialogueString;
		dialogueText.color = textC;

		//button text setup
		if(isUsingButton)
		{
			buttonText.text = "press " + buttonUsed.ToString();
			buttonText.color = textC;
		}
		else
		{
			buttonText.gameObject.SetActive(false);
			startTime = Time.time;
		}

		//create just above the target, or at the centre
		if(targetObj == null)
		{
			rectTransform.pivot = new Vector2(0.5f, 0.5f); //pivot is in the centre
			rectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, Vector3.zero);
		}
		else
		{
			rectTransform.pivot = new Vector2(0.5f, 0f); //pivot is at the bottom
			FollowTarget();
		}
	}

	private void Update()
	{
		//if(usingButton)
		if(targetObj != null)
		{
			FollowTarget();
		}

		if(isUsingButton)
		{
			if(Input.GetKeyUp(buttonUsed))
			{
				Destroy(this.gameObject);
			}
		}
		else
		{
			if(Time.time >= startTime + duration)
			{
				Destroy(this.gameObject);
			}
		}
	}

	private void OnDestroy()
	{
		BalloonDestroyed();
	}

	private void FollowTarget()
	{
		Vector3 topBoundary = targetObj.position;
		SpriteRenderer sr = targetObj.GetComponent<SpriteRenderer>();
		if(sr != null)
		{
			topBoundary.y += sr.bounds.size.y;
		}
		else
		{
			//the object is invisible in some way (has no SpriteRenderer)
			topBoundary.y = targetObj.position.y;
		}
		rectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, topBoundary);
	}
}
