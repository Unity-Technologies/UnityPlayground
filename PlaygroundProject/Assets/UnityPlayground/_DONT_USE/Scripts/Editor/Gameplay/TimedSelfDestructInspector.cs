using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(TimedSelfDestruct))]
public class TimedSelfDestructInspector : InspectorBase
{
	private string explanation = "This GameObject will self destruct after a set amount of time, useful for bullets so they don't accumulate.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();
	}
}
