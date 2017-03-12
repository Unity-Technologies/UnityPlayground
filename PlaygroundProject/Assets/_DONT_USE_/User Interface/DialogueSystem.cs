using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
	public GameObject balloonPrefab;
	//private static List<DialogueBalloonAction> balloons = new List<DialogueBalloonAction>();

	public void CreateBalloon(string dialogueString, bool usingButton, KeyCode button, Color backgroundC, Color textC, Transform targetObj = null)
	{
		BalloonScript b = GameObject.Instantiate(balloonPrefab).GetComponent<BalloonScript>();
		b.transform.SetParent(transform, false);
		b.Setup(dialogueString, usingButton, button, backgroundC, textC, targetObj);
	}
}
