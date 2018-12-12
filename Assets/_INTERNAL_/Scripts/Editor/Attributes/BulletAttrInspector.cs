using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(BulletAttribute))]
public class BulletAttrInspector : InspectorBase
{
	private string explanation = "When this object touches another that has the script DestroyForPoints, the Player will get a point.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);
	}
}
