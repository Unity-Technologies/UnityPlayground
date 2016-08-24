using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TriggerStayInArea))]
public class TriggerStayInAreaInspector : TriggerInspectorBase
{
	private string explanation = "Use this script to repeatedly perform an action when a gameObject is inside the trigger. The frequency of the action is defined by the \"Frequency\" parameter.";

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
		EditorGUILayout.PropertyField(serializedObject.FindProperty("frequency"));

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