using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEditorInternal;

[CanEditMultipleObjects]
[CustomEditor(typeof(ConditionKeyPress))]
public class ConditionKeyPressInspector : ConditionInspectorBase
{
	private bool t;
	private string explanation = "Use this script to perform an action when a button is pressed, released, or as long as it's kept pressed (in this case you get to choose the frequency).";

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);
		
		/*
		Texture2D headerBackground;
		GUIStyle g = new GUIStyle();
		headerBackground = Resources.Load<Texture2D>("Textures/Blue");
		g.normal.background = headerBackground;
		EditorGUILayout.BeginVertical(g);

		g.padding = new RectOffset(5,0,0,0);
		if(!EditorGUIUtility.isProSkin)
		{
			headerBackground = Resources.Load<Texture2D>("Textures/HeaderPers");
		}
		else
		{
			headerBackground = Resources.Load<Texture2D>("Textures/GreyPro");
		}
		g.normal.background = headerBackground;

		EditorGUILayout.BeginVertical(g);
		EditorGUI.indentLevel++;
		t = EditorGUILayout.Foldout(t, "Help");
		if(t)
		{
			EditorGUI.indentLevel--;
			//EditorGUILayout.HelpBox(explanation, MessageType.Info);
			GUISkin s = Resources.Load<GUISkin>("Playground");
			GUI.skin = s;
			GUILayout.Label(explanation, "HelpText");
			EditorGUI.indentLevel++;
			GUI.skin = null;
		}
		EditorGUI.indentLevel--;
        EditorGUILayout.EndVertical ();
        EditorGUILayout.EndVertical ();
		*/
 		
		GUILayout.Space(10);
		EditorGUILayout.PropertyField(serializedObject.FindProperty("happenOnlyOnce"));

		EditorGUILayout.PropertyField(serializedObject.FindProperty("keyToPress"));

		//discern the event type, and show the frequency if needed
		EditorGUILayout.PropertyField(serializedObject.FindProperty("eventType"));
		int eventType = serializedObject.FindProperty("eventType").intValue;
		if(eventType == 2)
		{
			EditorGUILayout.PropertyField(serializedObject.FindProperty("frequency"));
		}


		GUILayout.Space(10);
		DrawActionLists();

		serializedObject.ApplyModifiedProperties();
	}
}