using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(BoxCollider2D))]
public class BoxCollider2DInspector : Collider2DInspectorBase
{

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		EditorGUILayout.Separator();
		EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Size"));
		EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Offset"));
		EditorGUILayout.PropertyField(serializedObject.FindProperty("m_AutoTiling"));
		EditorGUILayout.PropertyField(serializedObject.FindProperty("m_IsTrigger"), new GUIContent("Is Trigger", triggerMessage));
		
		base.ShowExtrasBlock(new string[]{"m_Material", "m_EdgeRadius", "m_UsedByEffector", "m_UsedByComposite"});

		serializedObject.ApplyModifiedProperties();
	}
}
