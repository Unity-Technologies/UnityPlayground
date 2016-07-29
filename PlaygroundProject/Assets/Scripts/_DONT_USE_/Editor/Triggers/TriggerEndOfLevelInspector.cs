using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TriggerEndOfLevel))]
public class TriggerEndOfLevelInspector : BaseInspectorWindow
{
	private string explanation = "Use this script to load a new level (another Unity scene) when the Player enters the trigger.";
	private string sceneWarning = "WARNING: Make sure the scene is enabled in the Build Settings scenes list.";
	private string sceneInfo = "WARNING; To add a new level, save a Unity scene and then go to File > Build Settings... and add the scene to the list.";

	private string chosenTag;

	public override void OnInspectorGUI()
	{
		chosenTag = so.FindProperty("filterTag").stringValue;

		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);
		GUILayout.Space(5);

		// Show a tag selector to then use for the public property filterTag
		GUILayout.Space(10);
		chosenTag = EditorGUILayout.TagField("Tag to check for", chosenTag);

		bool displayWarning = false;
		if(EditorBuildSettings.scenes.Length > 0)
		{
			int sceneId = 0;
			string sceneNameProperty = so.FindProperty("levelName").stringValue;

			//get available scene names and clean the names
			string[] sceneNames = new string[EditorBuildSettings.scenes.Length];
			int i = 0;
			foreach(EditorBuildSettingsScene s in EditorBuildSettings.scenes)
			{
				int lastSlash = s.path.LastIndexOf("/");
				string shortPath = s.path.Substring(lastSlash+1, s.path.Length-7-lastSlash);
				sceneNames[i] = shortPath;
				
				if(shortPath == sceneNameProperty)
				{
					sceneId = i;
					
					if(!s.enabled)
					{
						displayWarning = true;
					}
				}

				i++;
			}

			
			//Display the selector
			sceneId = EditorGUILayout.Popup("Scene to load", sceneId, sceneNames);

			if(displayWarning)
			{
				EditorGUILayout.HelpBox(sceneWarning, MessageType.Warning);
			}
			
			so.FindProperty("levelName").stringValue = sceneNames[sceneId];
		}
		else
		{
			EditorGUILayout.Popup("Scene to load", 0, new string[]{"No scenes available!"});
			EditorGUILayout.HelpBox(sceneInfo, MessageType.Warning);
		}
		
		CheckIfTrigger(true);

		if (GUI.changed)
		{
			so.FindProperty("filterTag").stringValue = chosenTag;
			so.ApplyModifiedProperties();
		}
	}
}