using UnityEditor;
using UnityEngine;

#if DEFAULT_INSPECTORS
namespace Playground.Editor.DefaultComponents
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(EdgeCollider2D))]
	public class EdgeCollider2DInspector : Collider2DInspectorBase
	{

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.Separator();
			EditorGUILayout.PropertyField(serializedObject.FindProperty("m_EdgeRadius"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("m_IsTrigger"), new GUIContent("Is Trigger", triggerTooltip));
		
			//base.ShowExtrasBlock(new string[]{"m_Material", "m_Offset", "m_UsedByEffector"});

			serializedObject.ApplyModifiedProperties();
		}
	}
}

#endif