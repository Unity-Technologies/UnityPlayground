using UnityEngine;

// All component that require physics inherit from this class, for easy access to the Rigidbody2D component

namespace Playground.BaseClasses
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Physics2DObject : MonoBehaviour
    {
        // Older Unity versions have an obsolete Component.rigidbody2D that this hides (CS0108); newer ones removed it (CS0109)
#pragma warning disable CS0108, CS0109
        [HideInInspector] public new Rigidbody2D rigidbody2D;
#pragma warning restore CS0108, CS0109

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
}