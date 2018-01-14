using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(LoadLevelAction))]
public class LoadLevelActionInspector : InspectorBase
{
	private string explanation = "Use this script to restart the level, or load another one (load another Unity scene).";
	private string sceneWarning = "WARNING: Make sure the scene is enabled in the Build Settings scenes list.";
	private string sceneInfo = "WARNING; To add a new level, save a Unity scene and then go to File > Build Settings... and add the scene to the list.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		GUILayout.Space(10);
		bool displayWarning = false;
		if(EditorBuildSettings.scenes.Length > 0)
		{
			int sceneId = 0;
			string sceneNameProperty = serializedObject.FindProperty("levelName").stringValue;

			//get available scene names and clean the names
			string[] sceneNames = new string[EditorBuildSettings.scenes.Length + 1];
			sceneNames[0] = "RELOAD LEVEL";
			int i = 1;
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

			if(sceneId == 0)
			{
				serializedObject.FindProperty("levelName").stringValue = LoadLevelAction.SAME_SCENE; //this means same scene
			}
			else
			{
				serializedObject.FindProperty("levelName").stringValue = sceneNames[sceneId];
			}
		}
		else
		{
			EditorGUILayout.Popup("Scene to load", 0, new string[]{"No scenes available!"});
			EditorGUILayout.HelpBox(sceneInfo, MessageType.Warning);
		}

		if (GUI.changed)
		{
			serializedObject.ApplyModifiedProperties();
		}
	}
}