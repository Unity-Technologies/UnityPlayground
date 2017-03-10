using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class AutoMove : Physics2DObject
{
	public Mesh m;

	// These are the forces that will push the object every frame
	// don't forget they can be negative too!
	public float horizontalMovement = 1f;
	public float verticalMovement = 0f;


	//is the push relative or absolute to the world?
	public bool relative = true;

	
	// FixedUpdate is called once per frame
	void FixedUpdate ()
	{
		if(relative)
		{
			rigidbody2D.AddRelativeForce(new Vector2(horizontalMovement, verticalMovement) * 2f);
		}
		else
		{
			rigidbody2D.AddForce(new Vector2(horizontalMovement, verticalMovement) * 2f);
		}
	}



	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Vector2 orientation = new Vector2(horizontalMovement, verticalMovement);
		float length = orientation.magnitude;
		Gizmos.DrawWireMesh(m, transform.position, Quaternion.AngleAxis(Angle(orientation), Vector3.forward), Vector3.one * length);
	}

	public float Angle(Vector2 v)
	{
		if(v.x<0) return (Mathf.Atan2(v.x, v.y)*Mathf.Rad2Deg*-1)-360;
		else return -Mathf.Atan2(v.x,v.y)*Mathf.Rad2Deg;
	}
}
