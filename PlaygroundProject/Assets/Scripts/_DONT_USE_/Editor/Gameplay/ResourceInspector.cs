using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Resource))]
public class ResourceInspector : BaseInspectorWindow
{
	private string explanation = "When the Player touches this object, he will collect the specified amount of this type of resource.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();

		CheckIfTrigger(true);
	}
}
