using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DestroyForPoints))]
public class DestroyForPointsInspector : BaseInspectorWindow
{
	private string explanation = "When this object is destroyed, the player gets a point.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();
	}
}
