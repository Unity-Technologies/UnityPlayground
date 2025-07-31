using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Auto Rotate")]
[HelpURL("https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-1/#Auto_Rotate%EF%BC%88%E4%B8%80%E5%AE%9A%E9%80%9F%E5%BA%A6%E3%81%A7%E5%9B%9E%E8%BB%A2%E3%81%99%E3%82%8B%EF%BC%89")]
[RequireComponent(typeof(Rigidbody2D))]
public class AutoRotate : Physics2DObject
{

    // This is the force that rotate the object every frame
    public float rotationSpeed = 5;

    private float currentRotation;


    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        // Find the right rotation, according to speed
        // まず rotation のみを計算する
        currentRotation += .02f * rotationSpeed * 10f;

        // Apply the rotation to the Rigidbody2d
        // 計算した rotation をオブジェクトに適用する。Transform ではなく Rigidbody を使って回転させると、衝突する場合は回転が妨げられる。
        rigidbody2D.MoveRotation(-currentRotation);
    }

    //Draw an arrow to show the direction in which the object will rotate
    // オブジェクトが回転する方向を gizmo として表示する
    void OnDrawGizmosSelected()
    {
        if (this.enabled)
        {
            Utils.DrawRotateArrowGizmo(transform.position, rotationSpeed);
        }
    }
}
