using UnityEngine;
using System.Collections;

public class Utils
{
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
}
