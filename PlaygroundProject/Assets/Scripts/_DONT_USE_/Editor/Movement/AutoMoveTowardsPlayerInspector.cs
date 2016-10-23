using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(AutoMoveTowardsPlayer))]
public class AutoMoveTowardsPlayerInspector : BaseInspectorWindow
{
	private string explanation = "This gameObject will pursue the Player constantly.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		//Draw custom inspector
		EditorGUILayout.PropertyField(serializedObject.FindProperty("speed"));

		GUILayout.Space(10);

		SerializedProperty lookAtPlayerProperty = serializedObject.FindProperty("lookAtPlayer");

		lookAtPlayerProperty.boolValue = EditorGUILayout.BeginToggleGroup("Look at Player", lookAtPlayerProperty.boolValue);
		EditorGUILayout.PropertyField(serializedObject.FindProperty("useSide"));
		EditorGUILayout.EndToggleGroup();

		if (GUI.changed)
		{
			serializedObject.ApplyModifiedProperties();
		}
	}
}
