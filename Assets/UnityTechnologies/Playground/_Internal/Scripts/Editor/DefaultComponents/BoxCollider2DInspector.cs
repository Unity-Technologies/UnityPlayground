using UnityEditor;
using UnityEditor.EditorTools;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

#if DEFAULT_INSPECTORS
namespace Playground.Editor.DefaultComponents
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(BoxCollider2D))]
	public class BoxCollider2DInspector : Collider2DInspectorBase
	{
		public override VisualElement CreateInspectorGUI()
		{
			VisualElement container = new();
			
			InspectorElement.FillDefaultInspector(container, serializedObject, this);
			
			IMGUIContainer imguiContainer = new();
			imguiContainer.onGUIHandler += () =>
			{
				EditorGUILayout.Space(2f);
				EditorGUILayout.EditorToolbarForTarget(new GUIContent("Edit Collider"), target);
				EditorGUILayout.Space(2f);
			};
			
			container.Insert(0, imguiContainer);
			
			return container;
		}

		// public override void OnInspectorGUI()
		// {
		// 	serializedObject.Update();
		//
		// 	EditorGUILayout.Separator();
		// 	EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Size"));
		// 	EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Offset"));
		// 	EditorGUILayout.PropertyField(serializedObject.FindProperty("m_AutoTiling"));
		// 	EditorGUILayout.PropertyField(serializedObject.FindProperty("m_IsTrigger"), new GUIContent("Is Trigger", triggerMessage));
		//
		// 	base.ShowExtrasBlock(new string[]{"m_Material", "m_EdgeRadius", "m_UsedByEffector", "m_UsedByComposite"});
		//
		// 	serializedObject.ApplyModifiedProperties();
		// }
	}
}

#endif