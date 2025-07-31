using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Actions/Dialogue Balloon")]
[HelpURL("https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-2/#DialogueBalloonAction%EF%BC%88%E3%82%BB%E3%83%AA%E3%83%95%E3%82%92%E8%A1%A8%E7%A4%BA%E3%81%99%E3%82%8B%EF%BC%89")]
public class DialogueBalloonAction : Action
{
    [Header("Contents")]
    public string textToDisplay = "Hey!";
    public Color backgroundColor = new Color32(113, 132, 146, 255);
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
        if (!balloonIsActive)
        {
            DialogueSystem d = GameObject.FindObjectOfType<DialogueSystem>();
            if (d == null)
            {
                //Dialogue System is not in the scene
                //DialogueSystem コンポーネントがシーン内にない
                //Debug.LogWarning("You need a UI in the scene to display dialogue!");
                Debug.LogWarning("UserInterface がシーンにないので、ダイアログを表示することができません。");
                return false;
            }

            //Dialogue System is found
            //DialogSystem コンポーネントが見つかった
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
        yield return new WaitUntil(() => !balloonIsActive);
    }

    private void OnBalloonDestroyed()
    {
        b.BalloonDestroyed -= OnBalloonDestroyed;
        b = null;
        balloonIsActive = false;

        if (followingText != null)
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
