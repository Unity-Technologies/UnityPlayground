using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(HealthSystemAttribute))]
public class PlayerHealthInspector : InspectorBase
{
	private string explanation = "This scripts allows the Players or other objects to receive damage.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();
	}
}
