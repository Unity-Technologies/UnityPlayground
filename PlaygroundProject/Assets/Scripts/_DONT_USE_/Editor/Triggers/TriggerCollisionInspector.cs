using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TriggerCollision))]
public class TriggerCollisionInspector : BaseInspectorWindow
{
	private string explanation = "Use this script to perform an action when this gameObject collides with another.";

	private string chosenTag;

	public override void OnInspectorGUI()
	{
		chosenTag = so.FindProperty("filterTag").stringValue;

		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		// Show a tag selector to then use for the public property filterTag
		GUILayout.Space(10);
		GUILayout.BeginHorizontal();
		GUILayout.Label("Tag to check for:");
		chosenTag = EditorGUILayout.TagField(chosenTag);
		GUILayout.EndHorizontal();

		EditorGUILayout.PropertyField(so.FindProperty("colliderTouched"));

		CheckIfTrigger(false);

		if (GUI.changed)
		{
			so.FindProperty("filterTag").stringValue = chosenTag;
			so.ApplyModifiedProperties();
		}
	}
}