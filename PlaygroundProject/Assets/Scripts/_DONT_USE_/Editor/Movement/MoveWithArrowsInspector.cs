using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(MoveWithArrows))]
public class MoveWithArrowsInspector : BaseInspectorWindow
{
	private string explanation = "The gameObject moves at the pression of some keys. Choose between Arrows or WASD.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();
	}
}