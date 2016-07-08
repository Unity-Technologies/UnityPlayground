using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	[Header("Object to follow")]
	// This is the object that the camera will follow
	public Transform target;

	private Vector3 lerpedPosition;

	void FixedUpdate()
	{
		if(target != null)
		{
			lerpedPosition = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 10f);
			lerpedPosition.z = -10f;
		}
	}
	
	void LateUpdate ()
	{
		if(target != null)
		{
			transform.position = lerpedPosition;
		}
	}
}
