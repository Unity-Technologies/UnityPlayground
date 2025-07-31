using UnityEngine;
using System.Collections;

//This script has been suggested by Bryan Livingston (@BryanLivingston). Thanks Bryan!
[AddComponentMenu("Playground/Movement/Wander")]
[HelpURL("https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-1/#Wander%EF%BC%88%E3%81%86%E3%82%8D%E3%81%86%E3%82%8D%E3%81%99%E3%82%8B%EF%BC%89")]
[RequireComponent(typeof(Rigidbody2D))]
public class Wander : Physics2DObject
{
    [Header("Movement")]
    public float speed = 1f;
    public float directionChangeInterval = 3f;
    public bool keepNearStartingPoint = true;

    [Header("Orientation")]
    public bool orientToDirection = false;
    // The direction that the GameObject will be oriented to
    //オブジェクトが向く方向
    public Enums.Directions lookAxis = Enums.Directions.Up;

    private Vector2 direction;
    private Vector3 startingPoint;


    // Start is called at the beginning of the game
    private void Start()
    {
        //we don't want directionChangeInterval to be 0, so we force it to a minimum value ;)
        //方向を変える間隔を0にしたくないので、0.1より小さかったら0.1にする
        if (directionChangeInterval < 0.1f)
        {
            directionChangeInterval = 0.1f;
        }

        // we note down the initial position of the GameObject in case it has to hover around that (see keepNearStartingPoint)
        //keepNearStartingPoint == true の時に遠くへ行かないようにするために、最初の地点を記憶しておく
        startingPoint = transform.position;

        StartCoroutine(ChangeDirection());
    }

    // Calculates a new direction
    // 移動方向を計算する
    private IEnumerator ChangeDirection()
    {
        while (true)
        {
            //change the direction the player is going
            //オブジェクトが移動している方向を変える
            direction = Random.insideUnitCircle;

            // if we need to keep near the starting point...
            // スタート地点の近くにいなければならない場合は...
            if (keepNearStartingPoint)
            {
                // we measure the distance from it...
                // スタート地点からの距離を計算して...
                float distanceFromStart = Vector2.Distance(startingPoint, transform.position);
                // and if it's too much...
                // 距離が離れすぎている場合は...
                if (distanceFromStart > 1f + (speed * 0.1f))
                {
                    //... we get a direction that points back to the starting point
                    //... スタート地点に戻る方向に移動する
                    direction = (startingPoint - transform.position).normalized;
                }
            }

            //if the object has to look in the direction of movement
            //移動方向を向く設定をしている場合の処理
            if (orientToDirection)
            {
                Utils.SetAxisTowards(lookAxis, transform, direction);
            }

            // this will make Unity wait for some time before continuing the execution of the code
            // 次の処理をする前にウェイトを入れる
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    // FixedUpdate is called every frame when the physics are calculated
    private void FixedUpdate()
    {
        rigidbody2D.AddForce(direction * speed);
    }
}