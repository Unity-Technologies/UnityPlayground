using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Camera Follow")]
public class CameraFollow : MonoBehaviour
{
	[Header("Object to follow")]
	// This is the object that the camera will follow
	public Transform target;


	private Vector3 lerpedPosition;


	// FixedUpdate is called every frame, when the physics are calculated
	void FixedUpdate()
	{
		if(target != null)
		{
			// Find the right position between the camera and the object
			lerpedPosition = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 10f);
			lerpedPosition.z = -10f;
		}
	}



	// LateUpdate is called after all other objects have moved
	void LateUpdate ()
	{
		if(target != null)
		{
			// Move the camera in the position found previously
			transform.position = lerpedPosition;
		}
	}
}
