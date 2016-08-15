using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(RestartLevel))]
public class RestartLevelInspector : BaseInspectorWindow
{
	private string explanation = "Use this script to allow restarting of the current level when a key is pressed.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();
	}
}
