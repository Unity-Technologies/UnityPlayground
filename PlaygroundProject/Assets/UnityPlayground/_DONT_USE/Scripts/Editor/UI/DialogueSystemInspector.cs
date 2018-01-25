using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(DialogueSystem))]
public class DialogueSystemInspector : InspectorBase
{
	private string explanation = "This script is responsible of creating dialogue balloons. Create dialogues by using DialogueBalloonAction in Conditions.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);
	}
}
