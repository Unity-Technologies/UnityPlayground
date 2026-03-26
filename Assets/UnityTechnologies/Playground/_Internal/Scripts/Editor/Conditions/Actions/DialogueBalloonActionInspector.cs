using Playground.Conditions.Actions;
using Playground.Editor.BaseClasses;
using UnityEditor;
using UnityEngine;

namespace Playground.Editor.Conditions.Actions
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(DialogueBalloonAction))]
	public class DialogueBalloonActionInspector : InspectorBase
	{
		private string explanation = "Use this script to create a dialogue ballon on a character's head.";
		private string tipMessage = "TIP: Connect another DialogueBalloonAction in the last slot to create a continuous conversation.";

		public override void OnInspectorGUI()
		{
			GUILayout.Space(10);
			EditorGUILayout.HelpBox(explanation, MessageType.Info);

			//Contents
			EditorGUILayout.PropertyField(serializedObject.FindProperty("textToDisplay"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("backgroundColor"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("textColor"));

			//Options
			EditorGUILayout.PropertyField(serializedObject.FindProperty("targetObject"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("disappearMode"));
			int isUsingKey = serializedObject.FindProperty("disappearMode").intValue;
			if(isUsingKey == 1)
			{
				EditorGUILayout.PropertyField(serializedObject.FindProperty("keyToPress"));
			}
			else
			{
				EditorGUILayout.PropertyField(serializedObject.FindProperty("timeToDisappear"));
			}

			//Continue dialogue
			EditorGUILayout.PropertyField(serializedObject.FindProperty("followingText"));

			EditorGUILayout.HelpBox(tipMessage, MessageType.Info);

			if (GUI.changed)
			{
				serializedObject.ApplyModifiedProperties();
			}
		}
	}
}
