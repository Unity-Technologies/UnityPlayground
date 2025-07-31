using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Actions/On-Off")]
[HelpURL("https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-2/#OnOffAction%EF%BC%88%E3%82%AA%E3%83%96%E3%82%B8%E3%82%A7%E3%82%AF%E3%83%88%E3%81%AE%E6%9C%89%E5%8A%B9%E3%83%BB%E7%84%A1%E5%8A%B9%E3%82%92%E5%88%87%E3%82%8A%E6%9B%BF%E3%81%88%E3%82%8B%EF%BC%89")]
public class OnOffAction : Action
{
    public GameObject objectToAffect;
    public bool justMakeInvisible;

    // Changes the object state from active to inactive, and viceversa
    //オブジェクト (GameObject) をアクティブ⇔非アクティブにしたり、SpriteRenderer を無効にしたりする
    public override bool ExecuteAction(GameObject dataObject)
    {
        if (objectToAffect != null)
        {
            if (!justMakeInvisible)
            {
                objectToAffect.SetActive(!objectToAffect.activeSelf);
            }
            else
            {
                //in this case, we just make the object invisible
                //justMakeInvisible == true の場合は、SpriteRenderer コンポーネントのみを無効にして、見えなくする
                SpriteRenderer sr = objectToAffect.GetComponent<SpriteRenderer>();
                if (sr != null)
                {
                    sr.enabled = !sr.enabled;
                }
                else
                {
                    //the object doesn't have a Sprite Renderer component so the action can't be performed!
                    //オブジェクトが SpriteRenderer を持っていない場合は、このアクションは実行できない
                    return false;
                }
            }

            return true;
        }
        else
        {
            return false;
        }
    }
}
