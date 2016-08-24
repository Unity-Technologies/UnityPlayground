using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TriggerCollision))]
public class TriggerCollisionInspector : TriggerInspectorBase
{
	private string explanation = "Use this script to perform an action when this gameObject collides with another.";

	private string chosenTag;

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		chosenTag = serializedObject.FindProperty("filterTag").stringValue;

		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		GUILayout.Space(10);
		EditorGUILayout.PropertyField(serializedObject.FindProperty("happenOnlyOnce"));
		chosenTag = EditorGUILayout.TagField("Tag to check for", chosenTag);

		GUILayout.Space(10);
		DrawActionLists();

		CheckIfTrigger(false);

		if (GUI.changed)
		{
			serializedObject.FindProperty("filterTag").stringValue = chosenTag;
			serializedObject.ApplyModifiedProperties();
		}
	}
}