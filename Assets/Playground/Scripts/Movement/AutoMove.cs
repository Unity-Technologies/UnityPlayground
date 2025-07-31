using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Auto Move")]
[HelpURL("https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-1/#Auto_Move%EF%BC%88%E4%B8%80%E6%96%B9%E5%90%91%E3%81%AB%E5%8B%95%E3%81%8F%EF%BC%89")]
[RequireComponent(typeof(Rigidbody2D))]
public class AutoMove : Physics2DObject
{
    // These are the forces that will push the object every frame
    // don't forget they can be negative too!
    // オブジェクトを押す力を設定する。負の値を指定することもできる。
    public Vector2 direction = new Vector2(1f, 0f);

    //is the push relative or absolute to the world?
    // グローバル座標系（ワールド座標系）の方向に押すか、ローカル座標系の方向に押すかを決定する
    public bool relativeToRotation = true;

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        if (relativeToRotation)
        {
            rigidbody2D.AddRelativeForce(direction * 2f);
        }
        else
        {
            rigidbody2D.AddForce(direction * 2f);
        }
    }

    //Draw an arrow to show the direction in which the object will move
    // オブジェクトが移動する方向を矢印の gizmo として表示する
    void OnDrawGizmosSelected()
    {
        if (this.enabled)
        {
            float extraAngle = (relativeToRotation) ? transform.rotation.eulerAngles.z : 0f;
            Utils.DrawMoveArrowGizmo(transform.position, direction, extraAngle);
        }
    }
}
