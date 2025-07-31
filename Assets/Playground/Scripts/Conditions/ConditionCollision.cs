using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[AddComponentMenu("Playground/Conditions/Condition Collision")]
[HelpURL("https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-2/#ConditionCollision%EF%BC%88%E3%82%B3%E3%83%A9%E3%82%A4%E3%83%80%E3%83%BC%E3%82%92%E4%BD%BF%E3%81%A3%E3%81%A6%E3%82%A2%E3%82%AF%E3%82%B7%E3%83%A7%E3%83%B3%E3%82%92%E7%99%BA%E5%8B%95%E3%81%99%E3%82%8B%EF%BC%89")]
[RequireComponent(typeof(Collider2D))]
public class ConditionCollision : ConditionBase
{

    //This will create a dialog window asking for which dialog to add
    private void Reset()
    {
        Utils.Collider2DDialogWindow(this.gameObject, false);
    }

    // This function will be called when something touches the trigger collider
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(filterTag) || !filterByTag)
        {
            ExecuteAllActions(collision.gameObject);
        }
    }
}
