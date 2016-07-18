using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TriggerEnterArea))]
public class TriggerEnterAreaInspector : BaseInspectorWindow
{
	private string explanation = "Use this script to perform an action when a gameObject enters this trigger.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		EditorGUILayout.PropertyField(so.FindProperty("triggerEntered"));

		CheckIfTrigger(true);

		if (GUI.changed)
		{
			so.ApplyModifiedProperties();
		}
	}
}