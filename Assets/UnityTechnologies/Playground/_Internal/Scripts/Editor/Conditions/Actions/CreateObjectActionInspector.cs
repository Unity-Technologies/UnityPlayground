using Playground.Conditions.Actions;
using Playground.Editor.BaseClasses;
using UnityEditor;
using UnityEngine;

namespace Playground.Editor.Conditions.Actions
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(CreateObjectAction))]
	public class CreateObjectActionInspector : InspectorBase
	{
		private string explanation = "Use this script to create a new GameObject from a Prefab in a specific position.";

		public override void OnInspectorGUI()
		{
			GUILayout.Space(10);
			EditorGUILayout.HelpBox(explanation, MessageType.Info);

			GUILayout.Space(10);
			base.OnInspectorGUI();

			ShowPrefabWarning("prefabToCreate");
		}
	}
}
