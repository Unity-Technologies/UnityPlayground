using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Push")]
[HelpURL("https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-1/#Push%EF%BC%88%E3%82%AD%E3%83%BC%E3%82%92%E6%8A%BC%E3%81%97%E3%81%A6%E5%8A%9B%E3%82%92%E5%8A%A0%E3%81%88%E3%82%8B%EF%BC%89")]
[RequireComponent(typeof(Rigidbody2D))]
public class Push : Physics2DObject
{
    [Header("Input key")]

    // the key used to activate the push
    public KeyCode key = KeyCode.Space;

    [Header("Direction and strength")]

    // strength of the push, and the axis on which it is applied (can be X or Y)
    public float pushStrength = 5f;
    public Enums.Axes axis = Enums.Axes.Y;
    public bool relativeAxis = true;

    private bool keyPressed = false;
    private Vector2 pushVector;

    // Read the input from the player
    void Update()
    {
        keyPressed = Input.GetKey(key);
    }

    // FixedUpdate is called every frame when the physics are calculated
    void FixedUpdate()
    {
        if (keyPressed)
        {
            pushVector = Utils.GetVectorFromAxis(axis) * pushStrength;

            //Apply the push
            if (relativeAxis)
            {
                rigidbody2D.AddRelativeForce(pushVector);
            }
            else
            {
                rigidbody2D.AddForce(pushVector);
            }
        }
    }

    //Draw an arrow to show the direction in which the object will move
    // シーンを編集する時に、オブジェクトが移動する方向を示す矢印の gizmo を表示する
    void OnDrawGizmosSelected()
    {
        if (this.enabled)
        {
            float extraAngle = (relativeAxis) ? transform.rotation.eulerAngles.z : 0f;
            pushVector = Utils.GetVectorFromAxis(axis) * pushStrength;
            Utils.DrawMoveArrowGizmo(transform.position, pushVector, extraAngle, pushStrength * .5f);
        }
    }
}
