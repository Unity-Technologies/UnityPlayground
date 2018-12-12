using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

/* UNUSED FOR NOW

//[CustomEditor(typeof(SpriteRenderer), true)]
public class ComponentInspector : Editor {

	//Color proColor = (Color) new Color32 (56, 56, 56, 255);
   // Color persColor = (Color) new Color32 (194, 194, 194, 255);

	protected override void OnHeaderGUI()
	{
		var rect = EditorGUILayout.GetControlRect(false, 0f);
        /* rect.height = EditorGUIUtility.singleLineHeight;
        rect.y -= rect.height;
        rect.x = 48;
        rect.xMax -= rect.x * 2f; */
		
		/*
 
        //EditorGUI.DrawRect (rect, EditorGUIUtility.isProSkin ? proColor : persColor);

		Rect buttonPos = new Rect(EditorGUIUtility.currentViewWidth - 60, rect.y-EditorGUIUtility.singleLineHeight, 18, EditorGUIUtility.singleLineHeight-2);
		GUI.backgroundColor = Color.red;

		GUIStyle style = new GUIStyle(GUI.skin.button);
		style.fontStyle = FontStyle.Bold;
		style.fontSize = 15;
		style.padding = new RectOffset(0,0,0,0);
		style.margin = new RectOffset(0,0,0,0);
		style.contentOffset = new Vector2(-1f, -2f);
		style.alignment = TextAnchor.MiddleCenter;
		style.normal.textColor = Color.white;

		if(GUI.Button(buttonPos, "x", style))
		{
			DestroyImmediate(target);
		}
		GUI.backgroundColor = Color.white;
 
        //string header = "Ciao";
        //EditorGUI.LabelField (rect, header, EditorStyles.boldLabel);
		
	}

	public override void OnInspectorGUI()
	{
		OnHeaderGUI();
		DrawDefaultInspector();
	}
}

*/