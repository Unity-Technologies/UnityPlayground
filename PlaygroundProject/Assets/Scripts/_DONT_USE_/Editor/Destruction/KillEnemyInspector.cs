using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(KillEnemy))]
public class KillEnemyInspector : BaseInspectorWindow
{
	private string explanation = "This gameObject will kill enemies instantaneously on impact.";
	private string tip = "WARNING: Don't forget to tag the enemies as Enemy!";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();

		EditorGUILayout.HelpBox(tip, MessageType.Warning);
	}
}
