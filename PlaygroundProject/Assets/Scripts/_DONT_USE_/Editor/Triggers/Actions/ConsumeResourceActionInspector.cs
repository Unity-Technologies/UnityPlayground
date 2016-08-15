using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ConsumeResourceAction))]
public class ConsumeResourceActionInspector : BaseInspectorWindow
{
	private string explanation = "Use this script to check if the player has a specific resource. If he has it, it will be consumed and the action below will happen.";
	private string actionTip = "You can also decide to perform no action, only consume the resource.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();

		EditorGUILayout.HelpBox(actionTip, MessageType.Info);
	}
}
