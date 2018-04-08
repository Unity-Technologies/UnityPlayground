using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

#if GAMEOBJECT_HEADER

[CanEditMultipleObjects]
[CustomEditor(typeof(GameObject))]
public class TestScriptInspector : Editor {

	private Texture2D headerBackground;

	public void OnEnable()
	{
		if(!EditorGUIUtility.isProSkin)
		{
			headerBackground = Resources.Load<Texture2D>("Textures/HeaderPers");
		}
		else
		{
			headerBackground = Resources.Load<Texture2D>("Textures/HeaderPro");
		}
	}

	public override void OnInspectorGUI()
	{
		//do nothing
	}

	protected override void OnHeaderGUI()
	{
		GUIStyle boxStyle = new GUIStyle();
		boxStyle.padding = new RectOffset(15, 5, 15, 10);
		boxStyle.normal.background = headerBackground;
		GUIStyle fontStyle = new GUIStyle(GUI.skin.textField);
		fontStyle.fontSize = 12;

		GUILayout.BeginVertical(boxStyle);

			//Active toggle and GameObject's name
			GUILayout.BeginHorizontal();
				EditorGUILayout.PropertyField(serializedObject.FindProperty("m_IsActive"), GUIContent.none, GUILayout.Width(25));
				EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Name"), GUIContent.none, GUILayout.Height(17));
			GUILayout.EndHorizontal();

			GUILayout.Space(5);

			//Tags dropdown
			GUILayout.BeginHorizontal();
				GUILayout.Label("Tag", GUILayout.ExpandWidth(false));

				string[] options = InternalEditorUtility.tags; //final list of tag options, including the mixed tag placeholder character "–"
				int chosenTagId = 0; //number of tag chosen
				bool isMixedTag = false;

				//extra checks in case of multiple selection
				if(Selection.gameObjects.Length > 1)
				{
					//check if at least two objects have different tags		
					string firstTag = Selection.gameObjects[0].tag;
					foreach(GameObject go in Selection.gameObjects)
					{
						if(!go.CompareTag(firstTag))
						{
							//different tags, show placeholder character
							options = new string[InternalEditorUtility.tags.Length + 1];
							(new string[]{"―"}).CopyTo(options, 0);
							(InternalEditorUtility.tags).CopyTo(options, 1);
							isMixedTag = true;
							break;
						}
					}
				}

				if(!isMixedTag)
				{
					//find the actual tag's ID in the list
					chosenTagId = System.Array.IndexOf(InternalEditorUtility.tags, Selection.gameObjects[0].tag);
				}

				//display the actual UI Dropdown
				int oldTagId = chosenTagId;
				chosenTagId = EditorGUILayout.Popup(chosenTagId, options);

				if(oldTagId != chosenTagId)
				{
					//adjust id to account for the placeholder tag
					if(isMixedTag)
					{
						chosenTagId--;
					}
					string finalTag = InternalEditorUtility.tags[chosenTagId];
					serializedObject.FindProperty("m_TagString").stringValue = finalTag;

				}
			GUILayout.EndHorizontal();

		GUILayout.EndVertical();

		serializedObject.ApplyModifiedProperties();
		
		/*
		//Prints the names of all properties of an object
		SerializedProperty prop = serializedObject.GetIterator();
		if (prop.NextVisible(true)) {
			do {
				
				//EditorGUILayout.PropertyField(serializedObject.FindProperty(prop.name), true);
				Debug.Log(prop.name);
			}
			while (prop.NextVisible(false));
		}
		*/
	}
}

#endif