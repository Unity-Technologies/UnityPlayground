using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ObjectShooter))]
public class ObjectShooterInspector : BaseInspectorWindow
{
	private string explanation = "Spawns an object at the press of a button and it applies a force to it, along the Y axis.";
	private string hint = "If you want to shoot in another direction, apply this script to a child object and rotate it in the direction you want.";
	private string hint2 = "Don't forget to apply a Rigidbody2D to your projectiles, or they won't move!";

	public override void OnInspectorGUI()
	{
		GUILayout.Space (10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI ();

		EditorGUILayout.HelpBox(hint, MessageType.Info);
		EditorGUILayout.HelpBox(hint2, MessageType.Warning);
	}
}
