using UnityEngine;
using System.Collections;

public class DialogueBalloonAction : Action
{
	public Transform targetObject;

	public string textToDisplay = "Hey!";
	public Color backgroundColor = Color.blue;
	public Color textColor = Color.white;

	public DisappearMode disappearMode = DisappearMode.ButtonPress;
	public float timeToDisappear = 2f;
	public KeyCode keyToPress = KeyCode.Return;


	public override bool ExecuteAction(GameObject other)
	{
		GameObject.FindObjectOfType<DialogueSystem>().CreateBalloon(textToDisplay, (disappearMode == DisappearMode.ButtonPress), keyToPress, backgroundColor, textColor, targetObject);
		return true;
	}


	public enum DisappearMode
	{
		Time,
		ButtonPress,
	}
}
