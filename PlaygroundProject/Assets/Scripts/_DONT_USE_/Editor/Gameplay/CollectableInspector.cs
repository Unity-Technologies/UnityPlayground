using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Collectable))]
public class CollectableInspector : BaseInspectorWindow
{
	private string explanation = "When the Player touches this object, he will get a point.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();
	}
}
