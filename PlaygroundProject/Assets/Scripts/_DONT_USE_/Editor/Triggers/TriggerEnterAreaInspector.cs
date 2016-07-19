using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TriggerEnterArea))]
public class TriggerEnterAreaInspector : BaseInspectorWindow
{
	private string explanation = "Use this script to perform an action when a gameObject enters this trigger.";
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

		EditorGUILayout.PropertyField(so.FindProperty("triggerEntered"));

		CheckIfTrigger(true);

		if (GUI.changed)
		{
			so.FindProperty("filterTag").stringValue = chosenTag;
			so.ApplyModifiedProperties();
		}
	}
}