using UnityEngine;
using System.Collections;

public class ObjectShooter : MonoBehaviour
{
	[Header("Object creation")]
	
	public GameObject prefabToSpawn;

	// The key to press to create the objects/projectiles
	public KeyCode keyToPress = KeyCode.Space;

	[Header("Other options")]

	// The rate of creation, as long as the key is pressed
	public float creationRate = .5f;

	// The speed at which the object are shot along the Y axis
	public float shootingSpeed = 5f;

	private float timeOfLastSpawn;

	// Will be set to 0 or 1 depending on how the GameObject is tagged
	private int playerNumber;


	// Use this for initialization
	void Start ()
	{
		timeOfLastSpawn = -creationRate;

		// Set the player number based on the GameObject tag
		playerNumber = (gameObject.CompareTag("Player")) ? 0 : 1;
	}


	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKey(keyToPress)
		   && Time.time >= timeOfLastSpawn + creationRate)
		{
			GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
			newObject.transform.position = this.transform.position;
			newObject.transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z);
			newObject.tag = "Bullet";

			// push the created objects, but only if they have a Rigidbody2D
			Rigidbody2D rigidbody2D = newObject.GetComponent<Rigidbody2D>();
			if(rigidbody2D != null)
			{
				rigidbody2D.AddForce(transform.up * shootingSpeed, ForceMode2D.Impulse);
			}

			// add a Bullet component if the prefab doesn't already have one, and assign the player ID
			BulletAttribute b = newObject.GetComponent<BulletAttribute>();
			if(b == null)
			{
				b = newObject.AddComponent<BulletAttribute>();
			}
			b.playerId = playerNumber;



			timeOfLastSpawn = Time.time;
		}
	}
}
