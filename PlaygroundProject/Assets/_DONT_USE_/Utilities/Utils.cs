using UnityEngine;
using System.Collections;

public static class Utils
{
	public static Mesh arrowMesh;

	static Utils()
	{
		arrowMesh = Resources.Load<Mesh>("Meshes/Arrow");
	}

	public static void SetAxisTowards(Enums.Directions axis, Transform t, Vector2 direction)
	{
		switch(axis)
		{
			case Enums.Directions.Up:
				t.up = direction;
				break;
			case Enums.Directions.Down:
				t.up = -direction;
				break;
			case Enums.Directions.Right:
				t.right = direction;
				break;
			case Enums.Directions.Left:
				t.right = -direction;
				break;
		}
	}

	//Draws a green arrow in a certain direction, with support for an extraAngle (to make it relative to the gameObject's rotation) and a specific scale
	public static void DrawArrowGizmo(Vector3 position, Vector2 direction, float extraAngle, float scale = 0f)
	{
		Gizmos.color = Color.green;
		float arrowAngle = Angle(direction);

		if(scale == 0f)
		{
			//calculate it from the direction
			scale = direction.magnitude;
		}

		Gizmos.DrawMesh(arrowMesh, position, Quaternion.AngleAxis(arrowAngle + extraAngle, Vector3.forward), Vector3.one * scale);
	}

	public static float Angle(Vector2 inputVector)
	{
		if(inputVector.x<0) return (Mathf.Atan2(inputVector.x, inputVector.y)*Mathf.Rad2Deg*-1)-360;
		else return -Mathf.Atan2(inputVector.x,inputVector.y)*Mathf.Rad2Deg;
	}
}
