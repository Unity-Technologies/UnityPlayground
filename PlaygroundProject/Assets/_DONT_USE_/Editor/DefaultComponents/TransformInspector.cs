using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(Transform))]
public class TransformInspector : Editor
{
	private SerializedProperty xPos, yPos, rot, xScale, yScale;
	private Vector3 localEulerAngles = Vector3.zero;
	private Quaternion localRotation = Quaternion.identity;
	private Texture2D red, green, blue;

	private void OnEnable()
	{
		xPos = serializedObject.FindProperty("m_LocalPosition").FindPropertyRelative("x");
		yPos = serializedObject.FindProperty("m_LocalPosition").FindPropertyRelative("y");
		rot = serializedObject.FindProperty("m_LocalRotation").FindPropertyRelative("z");
		xScale = serializedObject.FindProperty("m_LocalScale").FindPropertyRelative("x");
		yScale = serializedObject.FindProperty("m_LocalScale").FindPropertyRelative("y");

		red = Resources.Load<Texture2D>("Textures/Red");
		green = Resources.Load<Texture2D>("Textures/Green");
		blue = Resources.Load<Texture2D>("Textures/Blue");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();
		EditorGUILayout.Separator();

		EditorGUI.BeginChangeCheck();

		GUIStyle style = new GUIStyle();
		style.fontStyle = FontStyle.Bold;
		
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PrefixLabel("Position");
		EditorGUIUtility.labelWidth = 12f;
		EditorGUIUtility.fieldWidth = 10f;		
		style.normal.background = red;
		EditorGUILayout.BeginHorizontal(style);
		EditorGUILayout.PropertyField(xPos);
		EditorGUILayout.EndHorizontal();
		style.normal.background = green;
		EditorGUILayout.BeginHorizontal(style);
		EditorGUILayout.PropertyField(yPos);
		EditorGUILayout.EndHorizontal();
		EditorGUIUtility.labelWidth = 0f;
		EditorGUIUtility.fieldWidth = 0f;
		if(GUILayout.Button("0", GUILayout.Width(30), GUILayout.Height(16)))
		{
			xPos.floatValue = 0f;
			yPos.floatValue = 0f;
		}
		EditorGUILayout.EndHorizontal();

		localRotation = serializedObject.FindProperty("m_LocalRotation").quaternionValue;
		localEulerAngles = localRotation.eulerAngles;
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PrefixLabel("Rotation");
		EditorGUIUtility.labelWidth = 12f;
		EditorGUIUtility.fieldWidth = 10f;
		style.normal.background = blue;
		Rect rekt = new Rect(0,0, 300, EditorGUIUtility.singleLineHeight);
		EditorGUI.BeginProperty(rekt, GUIContent.none, serializedObject.FindProperty("m_LocalRotation"));
		EditorGUILayout.BeginHorizontal(style);
		localEulerAngles.z = EditorGUILayout.FloatField("Z", localEulerAngles.z);
		EditorGUILayout.EndHorizontal();
		EditorGUI.EndProperty();
		EditorGUIUtility.labelWidth = 0f;
		EditorGUIUtility.fieldWidth = 0f;
		localRotation = Quaternion.Euler(localEulerAngles);
		bool resetRotation = GUILayout.Button("0", GUILayout.Width(30));
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PrefixLabel("Scale");
		EditorGUIUtility.labelWidth = 12f;
		EditorGUIUtility.fieldWidth = 10f;
		style.normal.background = red;
		EditorGUILayout.BeginHorizontal(style);
		EditorGUILayout.PropertyField(xScale);
		EditorGUILayout.EndHorizontal();
		style.normal.background = green;
		EditorGUILayout.BeginHorizontal(style);
		EditorGUILayout.PropertyField(yScale);
		EditorGUILayout.EndHorizontal();
		EditorGUIUtility.labelWidth = 0f;
		EditorGUIUtility.fieldWidth = 0f;

		if(GUILayout.Button("1", GUILayout.Width(30)))
		{
			xScale.floatValue = 1f;
			yScale.floatValue = 1f;
		}
		EditorGUILayout.EndHorizontal();

		bool changed = EditorGUI.EndChangeCheck();

		if(changed)
		{
			if(resetRotation)
			{
				serializedObject.FindProperty("m_LocalRotation").quaternionValue = Quaternion.identity;
			}
			else
			{
				serializedObject.FindProperty("m_LocalRotation").quaternionValue = localRotation;
			}
			serializedObject.ApplyModifiedProperties();
		}
	}
}
