using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[AddComponentMenu("")]
public class DialogueSystem : MonoBehaviour
{
	public GameObject balloonPrefab;
	//private static List<DialogueBalloonAction> balloons = new List<DialogueBalloonAction>();

	public BalloonScript CreateBalloon(string dialogueString, bool usingButton, KeyCode button, float timeToDisappear, Color backgroundC, Color textC, Transform targetObj = null)
	{
		BalloonScript b = GameObject.Instantiate(balloonPrefab).GetComponent<BalloonScript>();
		b.transform.SetParent(transform, false);
		b.Setup(dialogueString, usingButton, button, timeToDisappear, backgroundC, textC, targetObj);

		return b;
	}
}
