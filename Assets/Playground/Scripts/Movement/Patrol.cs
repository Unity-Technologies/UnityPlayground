using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Patrol")]
[HelpURL("https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-1/#Partrol%EF%BC%88%E6%8C%87%E5%AE%9A%E3%81%97%E3%81%9F%E5%BA%A7%E6%A8%99%E3%82%92%E5%B7%A1%E5%9B%9E%E3%81%99%E3%82%8B%EF%BC%89")]
[RequireComponent(typeof(Rigidbody2D))]
public class Patrol : Physics2DObject
{
    [Header("Movement")]
    public float speed = 5f;
    public float directionChangeInterval = 3f;

    [Header("Orientation")]
    public bool orientToDirection = false;
    public Enums.Directions lookAxis = Enums.Directions.Up;

    [Header("Stops")]
    public Vector2[] waypoints;

    private Vector2[] newWaypoints;
    private int currentTargetIndex;

    void Start()
    {
        currentTargetIndex = 0;

        newWaypoints = new Vector2[waypoints.Length + 1];
        int w = 0;
        for (int i = 0; i < waypoints.Length; i++)
        {
            newWaypoints[i] = waypoints[i];
            w = i;
        }

        //Add the starting position at the end, only if there is at least another point in the queue - otherwise it's on index 0
        // スタート地点を経由座標リストの最後に加える。ただし、経由座標が設定されていない場合は、スタート地点を0番目の要素にする
        int v = (newWaypoints.Length > 1) ? w + 1 : 0;
        newWaypoints[v] = transform.position;
        //waypoints = newWaypoints;

        if (orientToDirection)
        {
            Utils.SetAxisTowards(lookAxis, transform, ((Vector3)newWaypoints[1] - transform.position).normalized);
        }
    }

    public void FixedUpdate()
    {
        Vector2 currentTarget = newWaypoints[currentTargetIndex];

        rigidbody2D.MovePosition(transform.position + ((Vector3)currentTarget - transform.position).normalized * speed * Time.fixedDeltaTime);

        if (Vector2.Distance(transform.position, currentTarget) <= .1f)
        {
            //new waypoint has been reached
            // 経由座標に到達した時の処理 - 次の経由地を設定し、そこへ移動する
            currentTargetIndex = (currentTargetIndex < newWaypoints.Length - 1) ? currentTargetIndex + 1 : 0;
            if (orientToDirection)
            {
                currentTarget = newWaypoints[currentTargetIndex];
                Utils.SetAxisTowards(lookAxis, transform, ((Vector3)currentTarget - transform.position).normalized);
            }
        }
    }

    public void Reset()
    {
        waypoints = new Vector2[1];
        Vector2 thisPosition = transform.position;
        waypoints[0] = new Vector2(2f, .5f) + thisPosition;
    }
}