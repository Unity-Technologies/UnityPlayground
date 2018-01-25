using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(ResourceAttribute))]
public class ResourceAttrInspector : InspectorBase
{
	private string explanation = "When the Player touches this object, they will collect the specified amount of this type of resource.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();

		CheckIfTrigger(true);
	}
}
