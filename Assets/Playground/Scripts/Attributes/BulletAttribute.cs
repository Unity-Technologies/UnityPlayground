using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Bullet")]
[HelpURL("https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-1/#BulletAttribute%EF%BC%88%E5%BD%93%E3%81%9F%E3%81%A3%E3%81%9F%E7%9B%B8%E6%89%8B%E3%82%92%E7%A0%B4%E5%A3%8A%EF%BC%89")]
public class BulletAttribute : MonoBehaviour
{
    [HideInInspector]
    public int playerId;

    //This will create a dialog window asking for which dialog to add
    //Collder2D の形を選ばせるダイアログを表示する
    private void Reset()
    {
        Utils.Collider2DDialogWindow(this.gameObject, true);
    }
}
