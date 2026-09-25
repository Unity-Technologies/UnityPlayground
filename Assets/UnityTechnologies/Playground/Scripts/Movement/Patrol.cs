using Playground.BaseClasses;
using Playground.Utilities;
using UnityEngine;

namespace Playground.Movement
{
    [AddComponentMenu("Playground/Movement/Patrol")]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Patrol : Physics2DObject
    {
        [Header("Movement")] public float speed = 5f;

        [Header("Orientation")] public bool orientToDirection;

        public Enums.Directions lookAxis = Enums.Directions.Up;

        [Header("Stops")] public Vector2[] waypoints;

        private int currentTargetIndex;

        private Vector2[] newWaypoints;

        public void Reset()
        {
            waypoints = new Vector2[1];
            Vector2 thisPosition = transform.position;
            waypoints[0] = new Vector2(2f, .5f) + thisPosition;
        }

        private void Start()
        {
            currentTargetIndex = 0;

            // Copy the waypoints and add the starting position at the end, so the object loops back to it
            newWaypoints = new Vector2[waypoints.Length + 1];
            waypoints.CopyTo(newWaypoints, 0);
            newWaypoints[waypoints.Length] = transform.position;

            // Face the first stop (there is none if the list is empty)
            if (orientToDirection
                && waypoints.Length > 0)
                Utils.SetAxisTowards(lookAxis, transform, (newWaypoints[0] - rigidbody2D.position).normalized);
        }

        public void FixedUpdate()
        {
            Vector2 currentTarget = newWaypoints[currentTargetIndex];

            // MoveTowards never overshoots, so the object lands exactly on the waypoint
            Vector2 nextPosition =
                Vector2.MoveTowards(rigidbody2D.position, currentTarget, speed * Time.fixedDeltaTime);
            rigidbody2D.MovePosition(nextPosition);

            if (nextPosition == currentTarget)
            {
                // New waypoint has been reached
                currentTargetIndex = currentTargetIndex < newWaypoints.Length - 1 ? currentTargetIndex + 1 : 0;
                if (orientToDirection
                    && newWaypoints.Length > 1)
                {
                    currentTarget = newWaypoints[currentTargetIndex];
                    Utils.SetAxisTowards(lookAxis, transform, (currentTarget - nextPosition).normalized);
                }
            }
        }
    }
}