using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEditorInternal;

[CustomEditor(typeof(TriggerKeyPress))]
public class TriggerKeyPressInspector : TriggerInspectorBase
{
	private string explanation = "Use this script to perform an action when a button is pressed.";

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		GUILayout.Space(10);
		EditorGUILayout.PropertyField(serializedObject.FindProperty("happenOnlyOnce"));
		EditorGUILayout.PropertyField(serializedObject.FindProperty("keyToPress"));

		GUILayout.Space(10);
		DrawActionLists();

		serializedObject.ApplyModifiedProperties();
	}
}