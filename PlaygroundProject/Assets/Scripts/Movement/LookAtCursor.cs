using UnityEngine;
using System.Collections;

public class LookAtCursor : MonoBehaviour
{
	public Enums.Directions useSide = Enums.Directions.Up;
	
	void Update ()
	{
		Vector3 pointInSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//adjust the Z, because the Camera is at -10f on the Z!
		pointInSpace.z = 0f;
		//calculate the direction
		Vector3 directionToLookAt = (pointInSpace-transform.position).normalized;
		//orient the object
		Utils.SetAxisTowards(useSide, transform, directionToLookAt);
	}
}
