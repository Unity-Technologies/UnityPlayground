using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if DEFAULT_INSPECTORS

[CanEditMultipleObjects]
[CustomEditor(typeof(EdgeCollider2D))]
public class EdgeCollider2DInspector : Collider2DInspectorBase
{

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		EditorGUILayout.Separator();
		EditorGUILayout.PropertyField(serializedObject.FindProperty("m_EdgeRadius"));
		EditorGUILayout.PropertyField(serializedObject.FindProperty("m_IsTrigger"), new GUIContent("Is Trigger", triggerMessage));
		
		base.ShowExtrasBlock(new string[]{"m_Material", "m_Offset", "m_UsedByEffector"});

		serializedObject.ApplyModifiedProperties();
	}
}

#endif