using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Actions/Dialogue Balloon")]
public class DialogueBalloonAction : Action
{

	[Header("Contents")]
	public string textToDisplay = "Hey!";
	public Color backgroundColor = Color.blue;
	public Color textColor = Color.white;

	[Header("Options")]
	public Transform targetObject;
	public DisappearMode disappearMode = DisappearMode.ButtonPress;
	public float timeToDisappear = 2f;
	public KeyCode keyToPress = KeyCode.Return;

	[Header("Continue dialogue")]
	public DialogueBalloonAction followingText;

	private BalloonScript b;
	private bool balloonIsActive = false;


	public override bool ExecuteAction(GameObject other)
	{
		if(!balloonIsActive)
		{
			DialogueSystem d = GameObject.FindObjectOfType<DialogueSystem>();
			if(d == null)
			{
				//Dialogue System is not in the scene
				Debug.LogWarning("You need a UI in the scene to display dialogue!");
				return false;
			}
			
			//Dialogue System is found
			b = d.CreateBalloon(textToDisplay, (disappearMode == DisappearMode.ButtonPress), keyToPress, timeToDisappear, backgroundColor, textColor, targetObject);
			b.BalloonDestroyed += OnBalloonDestroyed;
			balloonIsActive = true;
			
			StartCoroutine(WaitForBallonDestroyed());
			return true;
		}
		else
		{
			return false;
		}
	}

	private IEnumerator WaitForBallonDestroyed()
	{
		yield return new WaitUntil(()=> !balloonIsActive);
	}


	private void OnBalloonDestroyed()
	{
		b.BalloonDestroyed -= OnBalloonDestroyed;
		b = null;
		balloonIsActive = false;

		if(followingText != null)
		{
			followingText.ExecuteAction(this.gameObject);
		}
	}

	public enum DisappearMode
	{
		Time = 0,
		ButtonPress = 1,
	}
}
