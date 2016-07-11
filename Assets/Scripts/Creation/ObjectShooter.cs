using UnityEngine;
using System.Collections;

public class ObjectShooter : MonoBehaviour
{
	[Header("Object creation")]
	
	public GameObject prefabToCreate;

	// The key to press to create the objects/projectiles
	public KeyCode keyToPress = KeyCode.Space;

	[Header("Other options")]

	// The rate of creation, as long as the key is pressed
	public float creationRate = .5f;

	// The speed at which the object are shot along the Y axis
	public float shootingSpeed = 5f;

	private float timeOfLastSpawn;


	// Use this for initialization
	void Start ()
	{
		timeOfLastSpawn = -creationRate;
	}


	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKey(keyToPress)
		   && Time.time >= timeOfLastSpawn + creationRate)
		{
			GameObject newObject = Instantiate<GameObject>(prefabToCreate);
			newObject.transform.position = this.transform.position;

			// push the created objects, but only if they have a Rigidbody2D
			Rigidbody2D rigidbody2D = newObject.GetComponent<Rigidbody2D>();
			if(rigidbody2D != null)
			{
				rigidbody2D.AddForce(transform.up * shootingSpeed, ForceMode2D.Impulse);
			}

			timeOfLastSpawn = Time.time;
		}
	}
}
