using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using System;
using System.IO;

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
		list.drawElementCallback =  (Rect rect, int index, bool isActive, bool isFocused) => {
			SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);
			rect.y += 2;
			Rect r = new Rect(rect.x, rect.y, rect.width - 20, EditorGUIUtility.singleLineHeight);
			EditorGUI.PropertyField(r, element, GUIContent.none, false);

			/*
			TODO: would be great to have but doesn't work for now
			//Add button at the end to unlink the Action?
			Rect buttonRect = new Rect(rect.width + 7, rect.y, 25, EditorGUIUtility.singleLineHeight);
			bool b = GUI.Button(buttonRect, "-");
			if(b)
			{
				//RemoveElement(index);
			}
			*/
		};


		//draws the header of the ReorderableList
		list.drawHeaderCallback = (Rect rect) => {
			EditorGUI.LabelField(rect, "Gameplay Actions");
		};

		list.onAddDropdownCallback = (Rect buttonRect, ReorderableList l) => {  
    		var menu = new GenericMenu();
			var guids = AssetDatabase.FindAssets("", new[]{"Assets/UnityTechnologies/Playground/Scripts/Conditions/Actions"});
			foreach (var guid in guids) {
				var path = AssetDatabase.GUIDToAssetPath(guid);
				string p = Path.GetFileNameWithoutExtension(path);
				menu.AddItem(new GUIContent(p), false, ClickHandler, p);
			}
			menu.AddItem(new GUIContent("- Empty slot -"), false, ClickHandler, "");
			menu.ShowAsContext();
		};

		list.onRemoveCallback += RemoveElement;
	}

	private void RemoveElement(ReorderableList l)
	{
		SerializedProperty element = l.serializedProperty.GetArrayElementAtIndex(l.index);
		
		if(element.objectReferenceValue != null)
		{
			Type t = element.objectReferenceValue.GetType();
			Undo.DestroyObjectImmediate(Selection.activeGameObject.GetComponent(t));
			element.objectReferenceValue = null;
		}

		ReorderableList.defaultBehaviours.DoRemoveButton(l);
	}

	public void ClickHandler(object actionName)
	{
		Component newComponent = null;
		if(actionName.ToString() != "")
		{
			//Assign the new Component
			Type t = Type.GetType(actionName + ",Assembly-CSharp");
			newComponent = Selection.activeGameObject.AddComponent(t);
		}

		//Add the list element
		var index = list.serializedProperty.arraySize;
		list.serializedProperty.arraySize++;
		list.index = index;
		var element = list.serializedProperty.GetArrayElementAtIndex(index);
		element.objectReferenceValue = newComponent; //connect the newly assigned component to it
		serializedObject.ApplyModifiedProperties();
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
