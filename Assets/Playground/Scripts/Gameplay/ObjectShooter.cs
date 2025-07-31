using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Gameplay/Object Shooter")]
[HelpURL("https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-1/#ObjectShooter%EF%BC%88%E3%82%AD%E3%83%BC%E3%82%92%E6%8A%BC%E3%81%97%E3%81%A6%E3%81%84%E3%82%8B%E9%96%93%E3%80%81%E3%82%AA%E3%83%96%E3%82%B8%E3%82%A7%E3%82%AF%E3%83%88%E3%82%92%E7%99%BA%E5%B0%84%E3%81%99%E3%82%8B%EF%BC%89")]
public class ObjectShooter : MonoBehaviour
{
    [Header("Object creation")]

    public GameObject prefabToSpawn;

    // The key to press to create the objects/projectiles
    // このキーを押すとオブジェクトを生成する
    public KeyCode keyToPress = KeyCode.Space;

    [Header("Other options")]

    // The rate of creation, as long as the key is pressed
    // キーを押し続けた時の連射間隔を秒で設定する
    public float creationRate = .5f;

    // The speed at which the object are shot along the Y axis
    public float shootSpeed = 5f;

    public Vector2 shootDirection = new Vector2(1f, 1f);

    public bool relativeToRotation = true;

    private float timeOfLastSpawn;

    // Will be set to 0 or 1 depending on how the GameObject is tagged
    // Tag に Player が付けられていたら 0、それ以外なら 1 が入る
    private int playerNumber;

    // Use this for initialization
    void Start()
    {
        timeOfLastSpawn = -creationRate;

        // Set the player number based on the GameObject tag
        // Tag を確認し、Player だったら 0、それ以外なら 1 を代入する
        playerNumber = (gameObject.CompareTag("Player")) ? 0 : 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyToPress)
           && Time.time >= timeOfLastSpawn + creationRate)
        {
            Vector2 actualBulletDirection = (relativeToRotation) ? (Vector2)(Quaternion.Euler(0, 0, transform.eulerAngles.z) * shootDirection) : shootDirection;

            GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
            newObject.transform.position = this.transform.position;
            newObject.transform.eulerAngles = new Vector3(0f, 0f, Utils.Angle(actualBulletDirection));
            newObject.tag = "Bullet";

            // push the created objects, but only if they have a Rigidbody2D
            // 生成したオブジェクトに力を加える。ただしそれが Rigidbody2D を持っている場合のみ
            Rigidbody2D rigidbody2D = newObject.GetComponent<Rigidbody2D>();
            if (rigidbody2D != null)
            {
                rigidbody2D.AddForce(actualBulletDirection * shootSpeed, ForceMode2D.Impulse);
            }

            // add a Bullet component if the prefab doesn't already have one, and assign the player ID
            // 割り当てられたプレハブに Bullet がついていなかったら追加する。また、弾にプレイヤーを識別するための番号を設定する（Player の場合は 0、それ以外の場合は 1
            BulletAttribute b = newObject.GetComponent<BulletAttribute>();
            if (b == null)
            {
                b = newObject.AddComponent<BulletAttribute>();
            }
            b.playerId = playerNumber;

            timeOfLastSpawn = Time.time;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (this.enabled)
        {
            float extraAngle = (relativeToRotation) ? transform.rotation.eulerAngles.z : 0f;
            Utils.DrawShootArrowGizmo(transform.position, shootDirection, extraAngle, 1f);
        }
    }
}
