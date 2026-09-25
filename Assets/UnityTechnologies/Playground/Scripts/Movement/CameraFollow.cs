using UnityEngine;

namespace Playground.Movement
{
    [AddComponentMenu("Playground/Movement/Camera Follow")]
    [RequireComponent(typeof(Camera))]
    public class CameraFollow : MonoBehaviour
    {
        // How quickly the camera catches up with the target (this value keeps the same feel as the previous version)
        private const float followSharpness = 11f;

        [Header("Object to follow")]
        // This is the object that the camera will follow
        public Transform target;

        // Bound camera to limits
        public bool limitBounds;
        public float left = -5f;
        public float right = 5f;
        public float bottom = -5f;
        public float top = 5f;

        private Camera _camera;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        // LateUpdate is called after all other objects have moved
        private void LateUpdate()
        {
            if (target == null)
                return;

            // Move towards the object, smoothly and independently of the frame rate
            // Only X and Y change, so the camera keeps its own Z
            Vector3 position = transform.position;
            float t = 1f - Mathf.Exp(-followSharpness * Time.deltaTime);
            position.x = Mathf.Lerp(position.x, target.position.x, t);
            position.y = Mathf.Lerp(position.y, target.position.y, t);

            // Bounds the camera to the limits (if enabled)
            if (limitBounds)
            {
                Vector2 halfView = GetHalfViewSize();
                position.x = ClampToBounds(position.x, left, right, halfView.x);
                position.y = ClampToBounds(position.y, bottom, top, halfView.y);
            }

            transform.position = position;
        }

        // Half the width and height of the area the camera sees on the game plane (Z = 0)
        private Vector2 GetHalfViewSize()
        {
            float halfHeight = _camera.orthographic
                ? _camera.orthographicSize
                : Mathf.Abs(transform.position.z) * Mathf.Tan(_camera.fieldOfView * .5f * Mathf.Deg2Rad);

            return new Vector2(halfHeight * _camera.aspect, halfHeight);
        }

        private static float ClampToBounds(float value, float min, float max, float halfView)
        {
            // If the view is bigger than the bounds, just keep it centred on them
            if (max - min < halfView * 2f) return (min + max) * .5f;

            return Mathf.Clamp(value, min + halfView, max - halfView);
        }
    }
}
