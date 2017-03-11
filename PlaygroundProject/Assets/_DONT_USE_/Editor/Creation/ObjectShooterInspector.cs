using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(ObjectShooter))]
public class ObjectShooterInspector : BaseInspectorWindow
{
	private string explanation = "Spawns an object at the press of a button and it applies a force to it, along the Y axis.";
	private string hint = "TIP: If you want to shoot in another direction, apply this script to a child object and rotate it in the direction you want.";
	private string warning = "WARNING: Don't forget to apply a Rigidbody2D to your projectiles, or they won't move!";

	public override void OnInspectorGUI()
	{
		GUILayout.Space (10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		bool prefabSelected = ShowPrefabWarning("prefabToSpawn");

		if(prefabSelected)
		{
			if(!CheckIfObjectUsesComponent<Rigidbody2D>("prefabToSpawn"))
			{
				EditorGUILayout.HelpBox(warning, MessageType.Warning);
			}
		}

		base.OnInspectorGUI();

		EditorGUILayout.HelpBox(hint, MessageType.Info);
	}
}
