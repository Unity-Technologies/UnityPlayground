using UnityEngine;
using System.Collections;

public class AutoObjectSpawner : MonoBehaviour
{
	[Header("Object creation")]

	// The object to spawn
	// WARNING: take if from the Project panel, NOT the Scene/Hierarchy!
	public GameObject prefabToSpawn;

	[Header("Other options")]

	// Configure the spawning pattern
	public float spawnInterval = 1;
	public float horizontalSize = 2;
	public float verticalSize = 2;

	void Start ()
	{
		StartCoroutine(SpawnObject());
	}
	
	// This will spawn an object, and then wait some time, then spawn another...
	IEnumerator SpawnObject ()
	{
		while(true)
		{
			// Create some random numbers
			float randomX = Random.Range (-horizontalSize, horizontalSize);
			float randomY = Random.Range (-verticalSize, verticalSize);

			// Generate the new object
			GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
			newObject.transform.position = new Vector2(randomX + this.transform.position.x, randomY + this.transform.position.y);

			// Wait for some time before spawning another object
			yield return new WaitForSeconds(spawnInterval);
		}
	}
}
