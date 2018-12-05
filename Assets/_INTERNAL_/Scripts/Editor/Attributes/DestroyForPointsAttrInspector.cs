using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(DestroyForPointsAttribute))]
public class DestroyForPointsAttrInspector : InspectorBase
{
	private string explanation = "When this object is destroyed, the player gets one or more points.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();
	}
}
