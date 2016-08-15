using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CreateObjectAction))]
public class CreateObjectActionInspector : BaseInspectorWindow
{
	private string explanation = "Use this script to create a new gameObject from a Prefab in a specific position.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();

		ShowPrefabWarning("prefabToCreate");
	}
}
