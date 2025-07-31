using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Rotate")]
[HelpURL("https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-1/#Rotate%EF%BC%88%E3%82%AD%E3%83%BC%E6%93%8D%E4%BD%9C%E3%81%A7%E5%9B%9E%E8%BB%A2%E3%81%99%E3%82%8B%EF%BC%89")]
[RequireComponent(typeof(Rigidbody2D))]
public class Rotate : Physics2DObject
{
    [Header("Input keys")]
    public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;

    [Header("Rotation")]
    public float speed = 5f;

    private float spin;


    // Update gets called every frame
    void Update()
    {
        // Register the spin from the player input
        // Moving with the arrow keys
        if (typeOfControl == Enums.KeyGroups.ArrowKeys)
        {
            spin = Input.GetAxis("Horizontal");
        }
        else
        {
            spin = Input.GetAxis("Horizontal2");
        }
    }

    // FixedUpdate is called every frame when the physics are calculated
    void FixedUpdate()
    {
        // Apply the torque to the Rigidbody2D
        // Rigidbody2D にトルク（回転する力）を加える
        rigidbody2D.AddTorque(-spin * speed);
    }
}
