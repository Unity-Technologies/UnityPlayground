using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BalloonScript : MonoBehaviour
{
	public Text dialogueText, buttonText;

	private RectTransform rectTransform;
	private bool isUsingButton;
	private KeyCode buttonUsed;

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
	}

	public void Setup(string dialogueString, bool usingButton, string buttonString, Color backgroundC, Color textC, GameObject targetObj = null)
	{
		//background setup
		GetComponent<Image>().color = backgroundC;

		//main dialogue text and colour
		dialogueText.text = dialogueString;
		dialogueText.color = textC;

		//button text setup
		if(usingButton)
		{
			buttonText.text = buttonString;
			buttonText.color = textC;
		}
		else
		{
			buttonText.gameObject.SetActive(false);
		}

		//create just above the target, or at the centre
		if(targetObj == null)
		{
			rectTransform.pivot = new Vector2(0.5f, 0.5f); //pivot is in the centre
			rectTransform.position = Vector3.zero;
		}
		else
		{
			rectTransform.pivot = new Vector2(0.5f, 0f); //pivot is at the bottom
			//rectTransform.position; //TODO: create world space position from targetObj
		}
	}

	private void Update()
	{
		//if(usingButton)
	}
}
