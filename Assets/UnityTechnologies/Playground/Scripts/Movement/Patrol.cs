using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Patrol")]
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

	void Start ()
	{
		currentTargetIndex = 0;

		newWaypoints = new Vector2[waypoints.Length+1];
		int w = 0;
		for(int i=0; i<waypoints.Length; i++)
		{
			newWaypoints[i] = waypoints[i];
			w = i;
		}

		//Add the starting position at the end, only if there is at least another point in the queue - otherwise it's on index 0
		int v = (newWaypoints.Length > 1) ? w+1 : 0;
		newWaypoints[v] = transform.position;
		//waypoints = newWaypoints;

		if(orientToDirection)
		{
			Utils.SetAxisTowards(lookAxis, transform, ((Vector3)newWaypoints[1] - transform.position).normalized);
		}
	}
	
	public void FixedUpdate ()
	{
		Vector2 currentTarget = newWaypoints[currentTargetIndex];

		rigidbody2D.MovePosition(transform.position + ((Vector3)currentTarget - transform.position).normalized * speed * Time.fixedDeltaTime);

		if(Vector2.Distance(transform.position, currentTarget) <= .1f)
		{
			//new waypoint has been reached
			currentTargetIndex = (currentTargetIndex<newWaypoints.Length-1) ? currentTargetIndex +1 : 0;
			if(orientToDirection)
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
		waypoints [0] = new Vector2 (2f, .5f) + thisPosition;
	}
}