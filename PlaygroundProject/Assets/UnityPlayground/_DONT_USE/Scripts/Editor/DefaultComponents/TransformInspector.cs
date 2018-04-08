using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if DEFAULT_INSPECTORS

[CanEditMultipleObjects]
[CustomEditor(typeof(Transform))]
public class TransformInspector : Editor
{
	private SerializedProperty xPos, yPos, xScale, yScale;
	private Vector3 localEulerAngles = Vector3.zero;
	private Quaternion localRotation = Quaternion.identity;
	private Texture2D red, green, blue;

	private void OnEnable()
	{
		xPos = serializedObject.FindProperty("m_LocalPosition").FindPropertyRelative("x");
		yPos = serializedObject.FindProperty("m_LocalPosition").FindPropertyRelative("y");
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

		GUIStyle style = new GUIStyle(GUI.skin.label);
		style.fontStyle = FontStyle.Bold;
		style.margin = new RectOffset(0,0,0,0);
		style.padding = new RectOffset(3,2,1,1);
		style.normal.textColor = new Color(.9f,.9f,.9f);
		
		EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel("Position");
			EditorGUIUtility.labelWidth = 12f;
			EditorGUIUtility.fieldWidth = 10f;
			style.normal.background = red;
			EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField("X", style, GUILayout.ExpandWidth(false), GUILayout.Width(14));
				EditorGUILayout.PropertyField(xPos, GUIContent.none);
			EditorGUILayout.EndHorizontal();
			style.normal.background = green;
			EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField("Y", style, GUILayout.ExpandWidth(false), GUILayout.Width(14));
				EditorGUILayout.PropertyField(yPos, GUIContent.none);
			EditorGUILayout.EndHorizontal();
			EditorGUIUtility.labelWidth = 0f;
			EditorGUIUtility.fieldWidth = 0f;
			if(GUILayout.Button("0", GUILayout.Width(30), GUILayout.Height(18)))
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
				EditorGUILayout.BeginHorizontal();
					EditorGUILayout.LabelField("Z", style, GUILayout.ExpandWidth(false), GUILayout.Width(14));
					localEulerAngles.z = EditorGUILayout.FloatField(localEulerAngles.z);
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
			EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField("X", style, GUILayout.ExpandWidth(false), GUILayout.Width(14));
				EditorGUILayout.PropertyField(xScale, GUIContent.none);
			EditorGUILayout.EndHorizontal();
			style.normal.background = green;
			EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField("Y", style, GUILayout.ExpandWidth(false), GUILayout.Width(14));
				EditorGUILayout.PropertyField(yScale, GUIContent.none);
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

#endif