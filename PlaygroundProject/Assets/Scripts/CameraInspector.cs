using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Camera))]
public class CameraInspector : Editor
{
	public override void OnInspectorGUI()
	{
		EditorGUILayout.PropertyField(serializedObject.FindProperty("m_BackGroundColor"), new GUIContent("Background Color"));
		EditorGUILayout.PropertyField(serializedObject.FindProperty("orthographic size"), new GUIContent("Size"));

		serializedObject.ApplyModifiedProperties();
	}
	
}
