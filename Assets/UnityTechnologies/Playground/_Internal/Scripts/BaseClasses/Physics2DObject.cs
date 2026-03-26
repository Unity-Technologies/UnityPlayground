using UnityEngine;

// All component that require physics inherit from this class, for easy access to the Rigidbody2D component

namespace Playground.BaseClasses
{
	[RequireComponent(typeof(Rigidbody2D))]
	public abstract class Physics2DObject : MonoBehaviour
	{
		[HideInInspector]
		public new Rigidbody2D rigidbody2D;

		private void Awake ()
		{
			rigidbody2D = GetComponent<Rigidbody2D>();
		}

	}
}
