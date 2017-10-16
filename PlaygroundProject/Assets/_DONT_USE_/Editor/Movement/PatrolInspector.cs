using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(Patrol))]
public class PatrolInspector : BaseInspectorWindow
{
	private string explanation = "The gameObject will move from side to side. This can  be used for patrolling enemies.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		EditorGUILayout.PropertyField(serializedObject.FindProperty("speed"));

		EditorGUILayout.PropertyField(serializedObject.FindProperty("directionChangeInterval"));

		GUILayout.Space(5);
		GUILayout.Label("Orientation", EditorStyles.boldLabel);
		bool orientToDirectionTemp = EditorGUILayout.Toggle("Orient to direction", serializedObject.FindProperty("orientToDirection").boolValue);
		if(orientToDirectionTemp)
		{
			EditorGUILayout.PropertyField(serializedObject.FindProperty("lookAxis"));
		}
		serializedObject.FindProperty("orientToDirection").boolValue = orientToDirectionTemp;

		serializedObject.ApplyModifiedProperties();
	}
}