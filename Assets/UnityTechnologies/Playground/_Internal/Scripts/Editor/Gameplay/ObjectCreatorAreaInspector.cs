using Playground.Editor.BaseClasses;
using Playground.Gameplay;
using UnityEditor;
using UnityEngine;

namespace Playground.Editor.Gameplay
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(ObjectCreatorArea))]
	public class ObjectCreatorAreaInspector : InspectorBase
	{
		private string explanation = "Creates an object repeatedly in a square area. The size of the area is defined by the size of BoxCollider2D, while Spawn Interval defines the delay of spawning.";
	
		public override void OnInspectorGUI()
		{
			GUILayout.Space (10);
			EditorGUILayout.HelpBox(explanation, MessageType.Info);

			ShowPrefabWarning("prefabToSpawn");

			base.OnInspectorGUI();

			CheckIfTrigger(true);
		}
	}
}
