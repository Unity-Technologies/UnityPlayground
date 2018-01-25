using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;

[CanEditMultipleObjects]
public class ConditionInspectorBase : InspectorBase
{

	protected ReorderableList list;
	protected string chosenTag;
	protected bool filterByTag;


	protected void OnEnable()
	{
		list = new ReorderableList(serializedObject, serializedObject.FindProperty("actions"), true, true, true, true);

		//called for every element that has to be drawn in the ReorderableList
		list.drawElementCallback =  
			(Rect rect, int index, bool isActive, bool isFocused) => {
			SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);
			rect.y += 2;
			Rect r = new Rect(rect.x, rect.y, rect.width - 40, EditorGUIUtility.singleLineHeight);
			EditorGUI.PropertyField(r, element, GUIContent.none, false);

			//Add button at the end to unlink the Action?
			Rect buttonRect = new Rect(rect.width + 7, rect.y, 25, EditorGUIUtility.singleLineHeight);
			bool b = GUI.Button(buttonRect, "X");
			if(b)
			{
				element.objectReferenceValue = null;
			}
		};


		//draws the header of the ReorderableList
		list.drawHeaderCallback = (Rect rect) => {
			EditorGUI.LabelField(rect, "Gameplay Actions");
		};
	}


	//draws the list ReorderableList of GameplayActions, the useCustomActions toggle and (if this is enabled) the default list of UnityEvents
	protected void DrawActionLists()
	{
		list.DoLayoutList();

		bool useCustom = EditorGUILayout.Toggle("Use custom actions", serializedObject.FindProperty("useCustomActions").boolValue);
		if(useCustom)
		{
			EditorGUILayout.PropertyField(serializedObject.FindProperty("customActions"));
		}
		serializedObject.FindProperty("useCustomActions").boolValue = useCustom;
	}


	//draws the tags as a dropdown only if the Filter by Tag toggle is enabled
	protected void DrawTagsGroup()
	{
		EditorGUILayout.PropertyField(serializedObject.FindProperty("happenOnlyOnce"));
		filterByTag = EditorGUILayout.Toggle("Filter by Tag", serializedObject.FindProperty("filterByTag").boolValue);
		if(filterByTag)
		{
			chosenTag = EditorGUILayout.TagField("Tag to check for", chosenTag);
		}
		serializedObject.FindProperty("filterByTag").boolValue = filterByTag;
	}
}
