using UnityEngine;
using System.Collections;

// All component that require physics inherit from this class, for easy access to the Rigidbody2D component

[RequireComponent(typeof(Rigidbody2D))]
public class Physics2DObject : MonoBehaviour
{
	[HideInInspector]
	public Rigidbody2D rb2D;

	void Awake ()
	{
		rb2D = GetComponent<Rigidbody2D>();
	}

}
