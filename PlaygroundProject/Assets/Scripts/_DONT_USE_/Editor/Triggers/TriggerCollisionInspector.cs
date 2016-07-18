using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TriggerCollision))]
public class TriggerCollisionInspector : BaseInspectorWindow
{
	private string explanation = "Use this script to perform an action when this gameObject collides with another.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		EditorGUILayout.PropertyField(so.FindProperty("colliderTouched"));

		CheckIfTrigger(false);

		if (GUI.changed)
		{
			so.ApplyModifiedProperties();
		}
	}
}