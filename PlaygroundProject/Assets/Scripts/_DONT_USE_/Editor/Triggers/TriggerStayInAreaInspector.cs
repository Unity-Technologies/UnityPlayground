using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TriggerStayInArea))]
public class TriggerStayInAreaInspector : BaseInspectorWindow
{
	private string explanation = "Use this script to repeatedly perform an action when a gameObject is inside the trigger. The frequency of the action is defined by the \"Frequency\" parameter.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		GUILayout.Space(10);
		EditorGUILayout.PropertyField(so.FindProperty("frequency"));

		EditorGUILayout.PropertyField(so.FindProperty("triggerStay"));
		
		CheckIfTrigger(true);

		if (GUI.changed)
		{
			so.ApplyModifiedProperties();
		}
	}
}