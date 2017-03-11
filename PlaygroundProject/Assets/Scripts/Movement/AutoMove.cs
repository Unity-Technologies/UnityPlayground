using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class AutoMove : Physics2DObject
{
	// These are the forces that will push the object every frame
	// don't forget they can be negative too!
	public Vector2 direction = new Vector2(1f, 0f);


	//is the push relative or absolute to the world?
	public bool relative = true;

	
	// FixedUpdate is called once per frame
	void FixedUpdate ()
	{
		if(relative)
		{
			rigidbody2D.AddRelativeForce(direction * 2f);
		}
		else
		{
			rigidbody2D.AddForce(direction * 2f);
		}
	}



	void OnDrawGizmosSelected()
	{
		if(this.enabled)
		{
			float extraAngle = (relative) ? transform.rotation.eulerAngles.z : 0f;
			Utils.DrawArrowGizmo(transform.position, direction, extraAngle);
		}
	}
}
