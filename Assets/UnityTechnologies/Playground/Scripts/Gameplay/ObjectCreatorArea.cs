using System.Collections;
using UnityEngine;

namespace Playground.Gameplay
{
    [AddComponentMenu("Playground/Gameplay/Object Creator Area")]
    [RequireComponent(typeof(BoxCollider2D))]
    public class ObjectCreatorArea : MonoBehaviour
    {
        [Header("Object creation")]

        // The object to spawn
        // WARNING: take if from the Project panel, NOT the Scene/Hierarchy!
        public GameObject prefabToSpawn;

        [Header("Other options")]

        // Configure the spawning pattern
        public float spawnInterval = 1;

        private BoxCollider2D boxCollider2D;

        private void Start()
        {
            boxCollider2D = GetComponent<BoxCollider2D>();

            if (prefabToSpawn == null)
            {
                Debug.LogWarning("There is no Prefab assigned to this Object Creator Area, so no objects will be created.");
                return;
            }

            // We don't want spawnInterval to be 0 (it would spawn every frame), so we force it to a minimum value
            if (spawnInterval < 0.1f) spawnInterval = 0.1f;

            StartCoroutine(SpawnObject());
        }

        // This will spawn an object, and then wait some time, then spawn another...
        private IEnumerator SpawnObject()
        {
            while (true)
            {
                // Pick a random point inside the box, in the collider's own space
                Vector2 halfSize = boxCollider2D.size * .5f;
                Vector2 localPoint = boxCollider2D.offset
                                     + new Vector2(Random.Range(-halfSize.x, halfSize.x),
                                         Random.Range(-halfSize.y, halfSize.y));

                // Generate the new object, converting the point to world space (this accounts for position, rotation and scale)
                GameObject newObject = Instantiate(prefabToSpawn);
                newObject.transform.position = (Vector2)transform.TransformPoint(localPoint);

                // Wait for some time before spawning another object
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }
}