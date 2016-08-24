using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditorInternal;

public class TriggerInspectorBase : BaseInspectorWindow
{

	protected ReorderableList list;



	protected void OnEnable()
	{
		list = new ReorderableList(serializedObject, serializedObject.FindProperty("actions"), true, true, true, true);

		list.drawElementCallback =  
			(Rect rect, int index, bool isActive, bool isFocused) => {
			SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index); //ActionItem
			rect.y += 2;
			EditorGUI.ObjectField(new Rect(rect.x, rect.y, rect.width - 30, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("connectedAction"), GUIContent.none);
		};

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
}
