using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : Physics2DObject
{
	
	[Header("Input key")]
	
	// the key used to activate the push
	public KeyCode key = KeyCode.Space;

	[Header("Strength")]
	
	// strength of the push
	public float pushStrength = 10f;

	// Read the input from the player
	void Update()
	{
		if(Input.GetKeyDown(key))
		{
			// Apply an instantaneous upwards force
			rigidbody2D.AddForce(Vector2.up * pushStrength, ForceMode2D.Impulse);
		}
	}
}
