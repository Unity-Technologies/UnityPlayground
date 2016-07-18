using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TriggerEndOfLevel))]
public class TriggerEndOfLevelInspector : BaseInspectorWindow
{
	private string explanation = "Use this script to load a new level (another Unity scene) when the Player enters the trigger.";
	private string sceneWarning = "WARNING: You need to add the level you want to load into the Build Settings. Go to File > Build Settings... and make sure the scene is in the list and enabled.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		GUILayout.Space(10);
		EditorGUILayout.PropertyField(so.FindProperty("playerOnly"));

		EditorGUILayout.DelayedTextField(so.FindProperty("levelName"));

		foreach(EditorBuildSettingsScene s in EditorBuildSettings.scenes)
		{
			if(!s.enabled
				|| !s.path.EndsWith(so.FindProperty("levelName").stringValue))
			{
				EditorGUILayout.HelpBox(sceneWarning, MessageType.Warning);
			}
		}
		
		CheckIfTrigger(true);

		if (GUI.changed)
		{
			so.ApplyModifiedProperties();
		}
	}
}