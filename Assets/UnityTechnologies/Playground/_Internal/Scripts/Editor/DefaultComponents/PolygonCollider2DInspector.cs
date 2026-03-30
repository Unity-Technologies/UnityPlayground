using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

#if DEFAULT_INSPECTORS
namespace Playground.Editor.DefaultComponents
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(PolygonCollider2D))]
	public class PolygonCollider2DInspector : Collider2DInspectorBase
	{
		public override VisualElement CreateInspectorGUI()
		{
			VisualElement container = new();
			
			container.Add(CreateEditColliderControls());
			
			PropertyField triggerPropField = new(serializedObject.FindProperty("m_IsTrigger"));
			triggerPropField.RegisterCallbackOnce<GeometryChangedEvent>(_ => triggerPropField.Q<Toggle>().tooltip = triggerTooltip);
			container.Add(triggerPropField);

			container.Add(CreateFoldout(new[] {"m_UsedByEffector", "m_Offset", "m_Material", "m_CompositeOperation"}));
			
			return container;
		}
	}
}

#endif