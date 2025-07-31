using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Actions/Create Object")]
[HelpURL("https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-2/#CreateObjectAction%EF%BC%88%E3%82%AA%E3%83%96%E3%82%B8%E3%82%A7%E3%82%AF%E3%83%88%E3%82%92%E7%94%9F%E6%88%90%E3%81%99%E3%82%8B%EF%BC%89")]
public class CreateObjectAction : Action
{
    public GameObject prefabToCreate;
    public Vector2 newPosition;
    public bool relativeToThisObject;

    // Creates a new GameObject
    public override bool ExecuteAction(GameObject dataObject)
    {
        if (prefabToCreate != null)
        {
            //create the new object by copying the prefab
            GameObject newObject = Instantiate<GameObject>(prefabToCreate);

            //is the position relative or absolute?
            Vector2 finalPosition = newPosition;
            if (relativeToThisObject)
            {
                finalPosition = (Vector2)transform.position + newPosition;
            }

            //let's place it in the desired position!
            newObject.transform.position = finalPosition;
            return true;
        }
        else
        {
            //Debug.LogWarning("There is no Prefab assigned to this CreateObjectAction, so a new object can't be created.");
            Debug.LogWarning("プレハブが指定されていません。オブジェクトを生成できません。");
            return false;
        }
    }
}
