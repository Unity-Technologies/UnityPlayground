using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Patrol : Physics2DObject
{
	// We set the direction to 1, as we only want to to switch between 2 directions
	private Vector2 direction = new Vector2(1f, 0f);

	[Header("Movement")]
	public float speed = 5f;
	public float directionChangeInterval = 3f;

	[Header("Orientation")]
	public bool orientToDirection = false;
	public Enums.Directions lookAxis = Enums.Directions.Up;


	// Start is called at the beginning of the game
	private void Start()
	{
		//we don't want directionChangeInterval to be 0, so we force it to a minimum value
		if(directionChangeInterval < 0.1f)
		{
			directionChangeInterval = 0.1f;
		}

		StartCoroutine(ChangeDirection());
	}




	// Calculates a new direction
	private IEnumerator ChangeDirection()
	{
		while(true)
		{
			// Stops the gameObject briefly to make the direction change quicker
			rigidbody2D.velocity = new Vector2(0,0);
			// turn the gameObject in the opposite direction
	 		direction = direction * (-1);


			//if the object has to look in the direction of movement
			if(orientToDirection)
			{
				Utils.SetAxisTowards(lookAxis, transform, direction);
			}


			// this will make Unity wait for some time before continuing the execution of the code
			yield return new WaitForSeconds(directionChangeInterval);
		}
	}



	// FixedUpdate is called every frame when the physics are calculated
	private void FixedUpdate()
	{
		rigidbody2D.AddForce(direction * speed);
	}

}