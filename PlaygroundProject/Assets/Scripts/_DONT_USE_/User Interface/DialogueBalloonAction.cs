using UnityEngine;
using System.Collections;

public class DialogueBalloonAction : Action
{
	public string textToDisplay;
	public Color backgroundColor;
	public Color textColor;

	public DisappearMode disappearMode;
	public float timeToDisappear;
	public KeyCode keyToPress;



	public enum DisappearMode
	{
		Time,
		ButtonPress,
	}
}
