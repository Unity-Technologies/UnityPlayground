using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DamagePlayer))]
public class DamagePlayerInspector : BaseInspectorWindow
{
	private string explanation = "This gameObject will damage the Player on impact.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();
	}
}
