using UnityEditor;
using UnityEngine;

#if DEFAULT_INSPECTORS
namespace Playground.Editor.DefaultComponents
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(CapsuleCollider2D))]
	public class CapsuleCollider2DInspector : Collider2DInspectorBase
	{

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.Separator();
			EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Size"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Direction"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("m_IsTrigger"), new GUIContent("Is Trigger", triggerMessage));
		
			base.ShowExtrasBlock(new string[]{"m_Material", "m_UsedByEffector", "m_UsedByComposite", "m_Offset"});

			serializedObject.ApplyModifiedProperties();
		}
	}
}

#endif