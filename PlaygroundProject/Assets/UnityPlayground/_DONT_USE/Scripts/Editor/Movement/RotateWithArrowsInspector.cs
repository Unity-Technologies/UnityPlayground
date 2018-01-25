using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(RotateWithArrows))]
public class RotateWithArrowsInspector : InspectorBase
{
	private string explanation = "The gameObject rotates at the press of the left-right arrow keys (or A-D keys for player 2).";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();
	}
}