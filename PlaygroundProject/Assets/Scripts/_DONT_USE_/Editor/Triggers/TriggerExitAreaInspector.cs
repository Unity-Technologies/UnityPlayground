using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TriggerExitArea))]
public class TriggerExitAreaInspector : BaseInspectorWindow
{
	private string explanation = "Use this script to perform an action when a gameObject exits from trigger.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		EditorGUILayout.PropertyField(so.FindProperty("triggerExited"));

		CheckIfTrigger(true);

		if (GUI.changed)
		{
			so.ApplyModifiedProperties();
		}
	}
}