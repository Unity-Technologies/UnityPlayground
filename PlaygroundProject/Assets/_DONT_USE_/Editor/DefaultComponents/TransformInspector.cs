using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(Transform))]
public class TransformInspector : Editor
{
	private Vector3 localPosition, localScale, localEulerAngles = Vector3.zero;
	private Quaternion localRotation = Quaternion.identity;

	public override void OnInspectorGUI()
	{
		serializedObject.Update();
		EditorGUILayout.Separator();

		EditorGUI.BeginChangeCheck();
		
		localPosition = serializedObject.FindProperty("m_LocalPosition").vector3Value;
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PrefixLabel("Position");
		EditorGUIUtility.labelWidth = 12f;
		EditorGUIUtility.fieldWidth = 10f;
		localPosition.x = EditorGUILayout.FloatField("X", localPosition.x);
		localPosition.y = EditorGUILayout.FloatField("Y", localPosition.y);
		EditorGUIUtility.labelWidth = 0f;
		EditorGUIUtility.fieldWidth = 0f;
		if(GUILayout.Button("0", GUILayout.Width(30)))
		{
			localPosition = Vector3.zero;
		}
		EditorGUILayout.EndHorizontal();

		localRotation = serializedObject.FindProperty("m_LocalRotation").quaternionValue;
		localEulerAngles = localRotation.eulerAngles;
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PrefixLabel("Rotation");
		EditorGUIUtility.labelWidth = 12f;
		EditorGUIUtility.fieldWidth = 10f;
		localEulerAngles.z = EditorGUILayout.FloatField("Z", localEulerAngles.z);
		EditorGUIUtility.labelWidth = 0f;
		EditorGUIUtility.fieldWidth = 0f;
		if(GUILayout.Button("0", GUILayout.Width(30)))
		{
			localEulerAngles = Vector3.zero;
		}
		localRotation = Quaternion.Euler(localEulerAngles);
		EditorGUILayout.EndHorizontal();

		localScale = serializedObject.FindProperty("m_LocalScale").vector3Value;
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PrefixLabel("Scale");
		EditorGUIUtility.labelWidth = 12f;
		EditorGUIUtility.fieldWidth = 10f;
		localScale.x = EditorGUILayout.FloatField("X", localScale.x);
		localScale.y = EditorGUILayout.FloatField("Y", localScale.y);
		EditorGUIUtility.labelWidth = 0f;
		EditorGUIUtility.fieldWidth = 0f;

		if(GUILayout.Button("1", GUILayout.Width(30)))
		{
			localScale = Vector3.one;
		}
		EditorGUILayout.EndHorizontal();

		bool changed = EditorGUI.EndChangeCheck();

		if(changed)
		{
			serializedObject.FindProperty("m_LocalPosition").vector3Value = localPosition;
			serializedObject.FindProperty("m_LocalRotation").quaternionValue = localRotation;
			serializedObject.FindProperty("m_LocalScale").vector3Value = localScale;
			serializedObject.ApplyModifiedProperties();
		}
	}
}
