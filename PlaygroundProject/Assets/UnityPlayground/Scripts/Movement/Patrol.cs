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
	public bool backToStart = true;
	public Vector2[] waypoints;

	private int currentTargetIndex;

	void Start ()
	{
		currentTargetIndex = 0;
		if(orientToDirection)
		{
			Utils.SetAxisTowards(lookAxis, transform, ((Vector3)waypoints[currentTargetIndex] - transform.position).normalized);
		}

		if(backToStart)
		{
			Vector2[] newWaypoints = new Vector2[waypoints.Length+1];
			int w = 0;
			for(int i=0; i<waypoints.Length; i++)
			{
				newWaypoints[i] = waypoints[i];
				w = i;
			}
			newWaypoints[w+1] = transform.position;
			waypoints = newWaypoints;
		}
	}
	
	public void FixedUpdate ()
	{
		Vector2 currentTarget = waypoints[currentTargetIndex];

		rigidbody2D.MovePosition(transform.position + ((Vector3)currentTarget - transform.position).normalized * speed * Time.fixedDeltaTime);

		if(Vector2.Distance(transform.position, currentTarget) <= .1f)
		{
			//new waypoint has been reached
			currentTargetIndex = (currentTargetIndex<waypoints.Length-1) ? currentTargetIndex +1 : 0;
			if(orientToDirection)
			{
				currentTarget = waypoints[currentTargetIndex];
				Utils.SetAxisTowards(lookAxis, transform, ((Vector3)currentTarget - transform.position).normalized);
			}
		}
	}

	public void Reset()
	{
		waypoints = new Vector2[1];
		Vector2 thisPosition = transform.position;
		waypoints [0] = new Vector2 (.5f, 2f) + thisPosition;
	}
}