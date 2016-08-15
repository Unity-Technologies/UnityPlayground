using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TeleportAction))]
public class TeleportActionInspector : BaseInspectorWindow
{
	private string explanation = "Use this script to teleport this or another object to a new location.";
	private string objectWarning = "If you don't assign a gameObject, this gameObject will be used.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();

		if(!CheckIfAssigned("objectToMove", false))
		{
			EditorGUILayout.HelpBox(objectWarning, MessageType.Warning);
		}
	}
}
