using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Rigidbody2D))]
public class Rigidbody2DInspector : Editor
{
	private bool constraintsGroup = false;
	private bool xConstraint = false, yConstraint = false, rotConstraint = false;
	private RigidbodyConstraints2D cachedConstraints;

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		EditorGUILayout.PropertyField(serializedObject.FindProperty("m_BodyType"));

		GUILayout.Space(5f);
		EditorGUILayout.LabelField("Physical Properties", EditorStyles.boldLabel);
		EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Mass"));
		EditorGUILayout.PropertyField(serializedObject.FindProperty("m_LinearDrag"), new GUIContent("Friction"));
		EditorGUILayout.PropertyField(serializedObject.FindProperty("m_AngularDrag"), new GUIContent("Angular Friction"));
		EditorGUILayout.PropertyField(serializedObject.FindProperty("m_GravityScale"));
		
		/*
		float gravity = serializedObject.FindProperty("m_GravityScale").floatValue;
		bool useGravity = (gravity == 0f);
		useGravity = EditorGUILayout.BeginToggleGroup("Gravity", useGravity);
		gravity = EditorGUILayout.FloatField("Amount", gravity);
		if(!useGravity)
		{
			serializedObject.FindProperty("m_GravityScale").floatValue = 0f;
		}
		else
		{
			serializedObject.FindProperty("m_GravityScale").floatValue = gravity;
		}
		EditorGUILayout.EndToggleGroup();
		*/

		//TODO: needs work
		GUILayout.Space(5f);
		constraintsGroup = EditorGUILayout.Foldout(constraintsGroup, new GUIContent("Constraints"));
		if(constraintsGroup)
		{
			//retrieve checkbox values
			cachedConstraints = (RigidbodyConstraints2D)serializedObject.FindProperty("m_Constraints").intValue;
			switch(cachedConstraints)
			{
				case RigidbodyConstraints2D.FreezePositionX:
					xConstraint = true;
					break;
				case RigidbodyConstraints2D.FreezePositionY:
					yConstraint = true;
					break;
				case RigidbodyConstraints2D.FreezePosition:
					xConstraint = true;
					yConstraint = true;
					break;
				case RigidbodyConstraints2D.FreezeRotation:
					rotConstraint = true;
					break;
				case RigidbodyConstraints2D.FreezeAll:
					xConstraint = true;
					yConstraint = true;
					rotConstraint = true;
					break;
			}


			EditorGUI.indentLevel++;
			EditorGUILayout.BeginHorizontal();
			//GUILayout.Label("Freeze Position", GUILayout.Width(EditorGUIUtility.labelWidth - 5f));
			EditorGUILayout.PrefixLabel("Freeze Position");
			xConstraint = GUILayout.Toggle(xConstraint, "X", GUILayout.ExpandWidth(false));
			yConstraint = GUILayout.Toggle(yConstraint, "Y", GUILayout.ExpandWidth(false));
			EditorGUILayout.EndHorizontal();


			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel("Freeze Rotation");
			rotConstraint = GUILayout.Toggle(rotConstraint, "Z");
			EditorGUILayout.EndHorizontal();
			EditorGUI.indentLevel--;

			if(!xConstraint && !yConstraint && !rotConstraint) cachedConstraints = RigidbodyConstraints2D.None;
			if(xConstraint && !yConstraint && !rotConstraint) cachedConstraints = RigidbodyConstraints2D.FreezePositionX;
			if(!xConstraint && yConstraint && !rotConstraint) cachedConstraints = RigidbodyConstraints2D.FreezePositionY;
			if(xConstraint && yConstraint && !rotConstraint) cachedConstraints = RigidbodyConstraints2D.FreezePosition;
			if(!xConstraint && !yConstraint && rotConstraint) cachedConstraints = RigidbodyConstraints2D.FreezeRotation;
			if(xConstraint && yConstraint && rotConstraint) cachedConstraints = RigidbodyConstraints2D.FreezeAll;

			serializedObject.FindProperty("m_Constraints").intValue = (int)cachedConstraints;
		}

		serializedObject.ApplyModifiedProperties();
	}
}
