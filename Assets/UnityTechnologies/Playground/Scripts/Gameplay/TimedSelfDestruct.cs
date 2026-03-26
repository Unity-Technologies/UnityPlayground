using UnityEngine;

namespace Playground.Gameplay
{
	[AddComponentMenu("Playground/Gameplay/Timed Self-Destruct")]
	public class TimedSelfDestruct : MonoBehaviour
	{

		// After this time, the object will be destroyed
		public float timeToDestruction;


		private void Start ()
		{
			Invoke("DestroyMe", timeToDestruction);
		}


		// This function will destroy this object :(
		private void DestroyMe()
		{
			Destroy(gameObject);

			// Bye bye!
		}
	}
}
