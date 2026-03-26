using Playground.Attributes;
using Playground.Editor.BaseClasses;
using UnityEditor;
using UnityEngine;

namespace Playground.Editor.Attributes
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(BulletAttribute))]
	public class BulletAttrInspector : InspectorBase
	{
		private string explanation = "When this object touches another that has the script DestroyForPoints, the Player will get a point.";

		public override void OnInspectorGUI()
		{
			GUILayout.Space(10);
			EditorGUILayout.HelpBox(explanation, MessageType.Info);
		}
	}
}
