using UnityEngine;
using System.Collections;

public static class Utils
{
	public static Mesh moveArrowMesh, shootArrowMesh, rotateArrowMesh;

	static Utils()
	{
		moveArrowMesh = Resources.Load<Mesh>("Meshes/MoveArrow");
		shootArrowMesh = Resources.Load<Mesh>("Meshes/ShootArrow");
		rotateArrowMesh = Resources.Load<Mesh>("Meshes/RotateArrow");
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

	//Always returns positive vectors!
	public static Vector2 GetVectorFromAxis(Enums.Axes axis)
	{
		if(axis == Enums.Axes.X)
		{
			return Vector2.right;
		}
		else
		{
			return Vector2.up;
		}
	}

	public static Vector2 GetVector2FromVector3(Vector3 input)
	{
		return new Vector2(input.x, input.y);
	}

	public static void DrawMoveArrowGizmo(Vector3 position, Vector2 direction, float extraAngle = 0f, float scale = 0f)
	{
		DrawGizmo(moveArrowMesh, position, direction, extraAngle, scale);
	}

	public static void DrawShootArrowGizmo(Vector3 position, Vector2 direction, float extraAngle = 0f, float scale = 0f)
	{
		DrawGizmo(shootArrowMesh, position, direction, extraAngle, scale);
	}

	public static void DrawRotateArrowGizmo(Vector3 position, float strength)
	{
		Gizmos.color = Color.green;
		Gizmos.DrawMesh(rotateArrowMesh, position, Quaternion.identity, new Vector3(Mathf.Sign(strength), 1f, Mathf.Sign(strength)));
	}

	//Draws a gizmo in a certain direction, with support for an extraAngle (to make it relative to the GameObject's rotation) and a specific scale
	public static void DrawGizmo(Mesh meshToDraw, Vector3 position, Vector2 direction, float extraAngle, float scale)
	{
		Gizmos.color = Color.green;
		float arrowAngle = Angle(direction);
		
		if(scale == 0f)
		{
			//calculate it from the direction
			scale = direction.magnitude;
		}

		Gizmos.DrawMesh(meshToDraw, position, Quaternion.AngleAxis(arrowAngle + extraAngle, Vector3.forward), Vector3.one * scale);
	}

	public static float Angle(Vector2 inputVector)
	{
		if(inputVector.x<0) return (Mathf.Atan2(inputVector.x, inputVector.y)*Mathf.Rad2Deg*-1)-360;
		else return -Mathf.Atan2(inputVector.x,inputVector.y)*Mathf.Rad2Deg;
	}


	//Called by Reset functions of scripts that require a Collider2D of any type
	//Unity displays a modal dialog window asking for which type of Collider2D to add
	public static void Collider2DDialogWindow(GameObject gameObjectRef, bool makeItTrigger = false)
	{
#if UNITY_EDITOR
		//Check first if a Collider2D is already present
		if(gameObjectRef.GetComponent<Collider2D>() != null)
		{
			return;
		}

		//If not, popup a window offering a choice		
        int option = UnityEditor.EditorUtility.DisplayDialogComplex("Collider2D needed",
                "This script requires a Collider2D to work. Which shape do you want it to be?\n\nIf you are not sure, choose Polygon.",
                "Polygon",
                "Circle",
                "Rectangle");


        switch (option)
        {
            //Polygon
            case 0:
                gameObjectRef.AddComponent<PolygonCollider2D>().isTrigger = makeItTrigger;
                break;

            //Circle
            case 1:
				gameObjectRef.AddComponent<CircleCollider2D>().isTrigger = makeItTrigger;
                break;

            //Rectangle
            case 2:
                gameObjectRef.AddComponent<BoxCollider2D>().isTrigger = makeItTrigger;
                break;

            default:
                Debug.LogWarning("Please add a Collider2D of any type or the script will not work as expected.");
                break;
        }
#endif
	}
}
