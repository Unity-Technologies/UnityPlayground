using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DestroyOnCollision))]
public class DestroyOnCollisionInspector : BaseInspectorWindow
{
	private string explanation = "This gameObject will destroy any object instantaneously on impact.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();
	}
}
