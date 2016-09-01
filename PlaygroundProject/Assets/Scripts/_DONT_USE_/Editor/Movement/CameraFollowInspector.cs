using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(CameraFollow))]
public class CameraFollowInspector : BaseInspectorWindow
{
	private string explanation = "This script makes the Camera follow a specific object (usually the Player).";
	private string warning = "WARNING: No object is selected, so the Camera won't move.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();

		if(!CheckIfAssigned("target", false))
		{
			EditorGUILayout.HelpBox(warning, MessageType.Warning);
		}
	}
}
