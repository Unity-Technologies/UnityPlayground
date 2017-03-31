using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(LookAtCursor))]
public class LookAtCursorInspector : BaseInspectorWindow
{
	private string explanation = "The gameObject looks towards the mouse cursor.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();
	}
}