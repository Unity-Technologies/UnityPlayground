using UnityEngine;

[AddComponentMenu("Playground/Gameplay/Pick Up And Hold")]
[HelpURL("https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-1/#PickUpAndHold%EF%BC%88%E3%82%AA%E3%83%96%E3%82%B8%E3%82%A7%E3%82%AF%E3%83%88%E3%82%92%E6%8C%81%E3%81%A3%E3%81%9F%E3%82%8A%E7%BD%AE%E3%81%84%E3%81%9F%E3%82%8A%E3%81%99%E3%82%8B%EF%BC%89")]
public class PickUpAndHold : MonoBehaviour
{
    //pickup key and drop key could be the same
    // ピックアップするキーとドロップするキーは同じでもよい
    public KeyCode pickupKey = KeyCode.B;
    public KeyCode dropKey = KeyCode.B;

    // An object need to closer than that distance to be picked up.
    // この距離 (m) より近ければ、オブジェクトをピックアップできる
    public float pickUpDistance = 2f;
    //public float hitToDropObject = Mathf.Infinity; //if the character hits anything with a force stronger than this value, the pickup is dropped

    private Transform carriedObject = null;

    private void Update()
    {
        bool justPickedUpSomething = false;

        if (Input.GetKeyDown(pickupKey)
            && carriedObject == null)
        {
            //Nothing in hand, we check if something is around and pick it up.
            // 手ぶらなので、周りにピックアップできるものがないか探す
            justPickedUpSomething = PickUp();
            //Debug.Log("Pickup");
        }

        if (Input.GetKeyDown(dropKey)
            && carriedObject != null
            && !justPickedUpSomething)
        {
            //We're holding something already, we drop
            // 持っているものがあるので、ドロップする
            Drop();
            //Debug.Log("Drop");
        }
    }

    public void Drop()
    {
        Rigidbody2D rb2d = carriedObject.GetComponent<Rigidbody2D>();
        if (rb2d != null)
        {
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            rb2d.velocity = Vector2.zero;
        }
        //unparenting
        // 親子関係を解除する
        carriedObject.parent = null;
        //hands are free again
        // 持っているオブジェクトの参照をクリアする
        carriedObject = null;
    }

    public bool PickUp()
    {
        //Collect every Pickup around
        // 拾えるオブジェクトを全てこの配列に入れる
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("Pickup");

        // Find the closest
        // 拾える範囲で一番近い所にあるオブジェクトを計算する
        float dist = pickUpDistance;
        for (int i = 0; i < pickups.Length; i++)
        {
            float newDist = (transform.position - pickups[i].transform.position).sqrMagnitude;
            if (newDist < dist)
            {
                carriedObject = pickups[i].transform;
                dist = newDist;
            }
        }

        // Check if we found something
        // 拾えるものがあるか確認する
        if (carriedObject != null)
        {
            //check if another player had it, in this case, steal it
            // もしそのオブジェクトが既に他のプレイヤーにピックアップされていた場合は横取りする
            Transform pickupParent = carriedObject.parent;
            if (pickupParent != null)
            {
                PickUpAndHold pickupScript = pickupParent.GetComponent<PickUpAndHold>();
                if (pickupScript != null)
                {
                    pickupScript.Drop();
                }
            }

            carriedObject.parent = gameObject.transform;
            // Set to Kinematic so it will move with the Player
            // Rigidbody の設定を Kinematic にして Transform の親子関係を設定することで、対象のオブジェクトをプレイヤーと一緒に動かせる
            Rigidbody2D rb2d = carriedObject.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                rb2d.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}