using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CustomActions))]
public class CustomActionsInspector : BaseInspectorWindow
{
	private string explanation = "Use this script together with triggers to produce some custom actions.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		EditorGUILayout.Vector3Field("Custom Position", so.FindProperty("customPosition").vector3Value);

		if(GUI.changed)
		{
			so.ApplyModifiedProperties();
		}
	}
}
