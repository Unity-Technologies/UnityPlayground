using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(ConsumeResourceAction))]
public class ConsumeResourceActionInspector : ConditionInspectorBase
{
	private string explanation = "Use this script to check if the player has a specific resource. If they have it, it will be consumed.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		GUILayout.Space(10);
		EditorGUILayout.PropertyField(serializedObject.FindProperty("checkFor"));
		EditorGUILayout.PropertyField(serializedObject.FindProperty("amountNeeded"));

		serializedObject.ApplyModifiedProperties();
	}
}
