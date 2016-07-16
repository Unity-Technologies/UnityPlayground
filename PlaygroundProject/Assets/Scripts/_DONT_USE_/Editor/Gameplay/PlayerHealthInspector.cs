using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(PlayerHealth))]
public class PlayerHealthInspector : BaseInspectorWindow
{
	private string explanation = "This scripts allows the Player to receive damage.";
	private string hint = "WARNING: You need to tag this gameObject as Player or Player2 for it to work.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();

		if(!CheckIfTaggedAs("Player")
			&& !CheckIfTaggedAs("Player2"))
		{
			EditorGUILayout.HelpBox(hint, MessageType.Warning);
		}
	}
}
