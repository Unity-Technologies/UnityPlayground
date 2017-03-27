using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(FollowPlayer))]
public class FollowPlayerInspector : BaseInspectorWindow
{
	private string explanation = "This gameObject will pursue the Player constantly.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		EditorGUILayout.PropertyField(serializedObject.FindProperty("targetPlayer"));

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
