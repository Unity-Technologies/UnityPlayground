using UnityEngine;
using System.Collections;

public class CustomActions : MonoBehaviour
{
	public Vector3 customPosition;

	// Moves the gameObject instantly to a custom position
	public void RestorePosition()
	{
		transform.position = customPosition; 
	}
}
