using UnityEditor;
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
			
			container.Add(CreateEditColliderControls());
			
			container.Add(new PropertyField(serializedObject.FindProperty("m_Size")));
			container.Add(new PropertyField(serializedObject.FindProperty("m_Offset")));
			
			PropertyField triggerPropField = new(serializedObject.FindProperty("m_IsTrigger"));
			triggerPropField.RegisterCallbackOnce<GeometryChangedEvent>(_ => triggerPropField.Q<Toggle>().tooltip = triggerTooltip);
			container.Add(triggerPropField);

			container.Add(CreateFoldout(new[] {"m_EdgeRadius", "m_Material", "m_AutoTiling", "m_UsedByEffector", "m_CompositeOperation"}));
			
			return container;
		}
	}
}

#endif