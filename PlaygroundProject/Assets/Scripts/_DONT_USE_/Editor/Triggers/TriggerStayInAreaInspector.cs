using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TriggerStayInArea))]
public class TriggerStayInAreaInspector : BaseInspectorWindow
{
	private string explanation = "Use this script to repeatedly perform an action when a gameObject is inside the trigger. The frequency of the action is defined by the \"Frequency\" parameter.";

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

		GUILayout.Space(10);
		EditorGUILayout.PropertyField(so.FindProperty("frequency"));

		EditorGUILayout.PropertyField(so.FindProperty("triggerStay"));
		
		CheckIfTrigger(true);

		if (GUI.changed)
		{
			so.FindProperty("filterTag").stringValue = chosenTag;
			so.ApplyModifiedProperties();
		}
	}
}