using Playground.Conditions.Actions;
using Playground.Editor.BaseClasses;
using UnityEditor;
using UnityEngine;

namespace Playground.Editor.Conditions.Actions
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(TeleportAction))]
	public class TeleportActionInspector : InspectorBase
	{
		private string explanation = "Use this script to teleport this or another object to a new location.";
		private string objectWarning = "WARNING: If you don't assign a GameObject, this GameObject will be teleported!";

		public override void OnInspectorGUI()
		{
			GUILayout.Space(10);
			EditorGUILayout.HelpBox(explanation, MessageType.Info);

			GUILayout.Space(10);
			EditorGUILayout.PropertyField(serializedObject.FindProperty("objectToMove"));

			if(!CheckIfAssigned("objectToMove", false))
			{
				EditorGUILayout.HelpBox(objectWarning, MessageType.Warning);
			}

			EditorGUILayout.PropertyField(serializedObject.FindProperty("newPosition"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("stopMovements"));

			if (GUI.changed)
			{
				serializedObject.ApplyModifiedProperties();
			}
		}
	}
}
