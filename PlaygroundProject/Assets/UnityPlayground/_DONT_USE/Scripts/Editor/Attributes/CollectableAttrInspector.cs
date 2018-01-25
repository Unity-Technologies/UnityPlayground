using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(CollectableAttribute))]
public class CollectableAttrInspector : InspectorBase
{
	private string explanation = "When the Player touches this object, the Player will get a point.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();

		CheckIfTrigger(true);
	}
}
