using UnityEngine;
using System.Collections;

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
			b = GameObject.FindObjectOfType<DialogueSystem>().CreateBalloon(textToDisplay, (disappearMode == DisappearMode.ButtonPress), keyToPress, timeToDisappear, backgroundColor, textColor, targetObject);
			b.BalloonDestroyed += OnBalloonDestroyed;
			balloonIsActive = true;
			
			StartCoroutine(WaitForBallonDestroyed());

			Debug.Log("Returning true");
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

		Debug.Log("Balloon destroyed");
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
