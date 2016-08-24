using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TriggerExitArea))]
public class TriggerExitAreaInspector : TriggerInspectorBase
{
	private string explanation = "Use this script to perform an action when a gameObject exits from trigger.";

	private string chosenTag;

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		chosenTag = serializedObject.FindProperty("filterTag").stringValue;

		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		// Show a tag selector to then use for the public property filterTag
		GUILayout.Space(10);
		EditorGUILayout.PropertyField(serializedObject.FindProperty("happenOnlyOnce"));
		chosenTag = EditorGUILayout.TagField("Tag to check for", chosenTag);

		GUILayout.Space(10);
		DrawActionLists();

		CheckIfTrigger(true);

		if (GUI.changed)
		{
			serializedObject.FindProperty("filterTag").stringValue = chosenTag;
			serializedObject.ApplyModifiedProperties();
		}
	}
}