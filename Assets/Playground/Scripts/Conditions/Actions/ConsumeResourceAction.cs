using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[AddComponentMenu("Playground/Actions/Consume Resource")]
[HelpURL("https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-2/#ConsumeResourceAction%EF%BC%88%E6%8C%81%E3%81%A3%E3%81%A6%E3%81%84%E3%82%8B%E3%82%A2%E3%82%A4%E3%83%86%E3%83%A0%E3%82%92%E6%B6%88%E8%B2%BB%E3%81%99%E3%82%8B%EF%BC%89")]
public class ConsumeResourceAction : Action
{
    [Header("Resource")]
    public int checkFor = 0;
    public int amountNeeded = 1;

    private UIScript userInterface;

    private void Start()
    {
        // Find the UI in the scene and store a reference for later use
        userInterface = GameObject.FindObjectOfType<UIScript>();
    }

    public override bool ExecuteAction(GameObject dataObject)
    {
        if (userInterface != null)
        {
            bool hasEnoughResource = userInterface.CheckIfHasResources(checkFor, amountNeeded);

            if (hasEnoughResource)
            {
                //consume the resource and update the UI
                //リソースを消費してUIを更新する
                userInterface.ConsumeResource(checkFor, amountNeeded);
            }

            return hasEnoughResource;
        }
        else
        {
            //Debug.LogWarning("User Interface prefab has not been found in the scene. The action can't execute!");
            Debug.LogWarning("UserInterface がシーン内にないので、この Action は実行できません。");
            return false;
        }
    }
}
