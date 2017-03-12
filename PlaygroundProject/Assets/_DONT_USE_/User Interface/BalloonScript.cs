using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BalloonScript : MonoBehaviour
{
	public Text dialogueText, buttonText;

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

	public void Setup(string dialogueString, bool _isUsingButton, KeyCode _buttonUsed, Color backgroundC, Color textC, Transform _targetObj = null)
	{
		isUsingButton = _isUsingButton;
		buttonUsed = _buttonUsed;
		targetObj = _targetObj;

		//background setup
		GetComponent<Image>().color = backgroundC;

		//main dialogue text and colour
		dialogueText.text = dialogueString;
		dialogueText.color = textC;

		//button text setup
		if(isUsingButton)
		{
			buttonText.text = "Press " + buttonUsed.ToString();
			buttonText.color = textC;
		}
		else
		{
			buttonText.gameObject.SetActive(false);
			startTime = Time.time;
			duration = 3f + dialogueString.Length * .1f;
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

	private void FollowTarget()
	{
		Vector3 topBoundary = targetObj.position;
		topBoundary.y += targetObj.GetComponent<SpriteRenderer>().bounds.size.y;
		rectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, topBoundary);
	}
}
