using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Camera Follow")]
public class CameraFollow : MonoBehaviour
{
	[Header("Object to follow")]
	// This is the object that the camera will follow
	public Transform target;

    //Bound camera to limits
    public bool limitBounds = false;
    public float xMin = 0f;
    public float xMax = 0f;
    public float yMin = -5f;
    public float yMax = 5f;

	private Vector3 lerpedPosition;

    private Camera _camera;

    private void Awake() {
        _camera = GetComponent<Camera>();
    }

    // FixedUpdate is called every frame, when the physics are calculated
    void FixedUpdate()
	{
		if(target != null)
		{
			// Find the right position between the camera and the object
			lerpedPosition = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 10f);
			lerpedPosition.z = -10f;
		}
	}



	// LateUpdate is called after all other objects have moved
	void LateUpdate ()
	{
		if(target != null)
		{
			// Move the camera in the position found previously
			transform.position = lerpedPosition;

            // Bounds the camera to the limits (if enabled)
            if(limitBounds) {
                Vector3 bottomLeft = _camera.ScreenToWorldPoint(Vector3.zero);
                Vector3 topRight = _camera.ScreenToWorldPoint(new Vector3(_camera.pixelWidth, _camera.pixelHeight));
                Vector2 screenSize = new Vector2(topRight.x - bottomLeft.x, topRight.y - bottomLeft.y);

                Vector3 boundPosition = transform.position;
                if (boundPosition.x > xMax - (screenSize.x / 2f)) {
                    boundPosition.x = xMax - (screenSize.x / 2f);
                }
                if (boundPosition.x < xMin + (screenSize.x / 2f)) {
                    boundPosition.x = xMin + (screenSize.x / 2f);
                }

                if (boundPosition.y > yMax - (screenSize.y / 2f)) {
                    boundPosition.y = yMax - (screenSize.y / 2f);
                }
                if (boundPosition.y < yMin + (screenSize.y / 2f)) {
                    boundPosition.y = yMin + (screenSize.y / 2f);
                }
                transform.position = boundPosition;
            }
		}
	}
}
