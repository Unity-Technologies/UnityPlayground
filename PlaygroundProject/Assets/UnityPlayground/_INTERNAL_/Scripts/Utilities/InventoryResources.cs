using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CreateAssetMenu]
public class InventoryResources : ScriptableObject
{
	[SerializeField]
	public List<string> resourcesTypes;

	public string[] GetResourceTypes()
	{
		//Just an annoying loop to switch the List<string> into an array of strings
		string[] resourceTypesArray = new string[resourcesTypes.Count];
		for(int i=0; i<resourcesTypes.Count; i++)
		{
			resourceTypesArray[i] = resourcesTypes[i];
		}
		
		return resourceTypesArray;
	}
}






[CustomEditor(typeof(InventoryResources))]
public class InventoryResourcesInspector : Editor
{
	private string explanation = "This is the list of Resources present in the game. Add and/or remove names here first, then go back to your Resource GameObjects and assign them a type.";
	private ReorderableList list;

	protected void OnEnable()
	{
		list = new ReorderableList(serializedObject, serializedObject.FindProperty("resourcesTypes"), false, true, true, true);

		//called for every element that has to be drawn in the ReorderableList
		list.drawElementCallback =  (Rect rect, int index, bool isActive, bool isFocused) => {
			SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);
			rect.y += 2;
			Rect r = new Rect(rect.x, rect.y, rect.width - 20, EditorGUIUtility.singleLineHeight);
			EditorGUI.PropertyField(r, element, GUIContent.none, false);
		};

		list.drawHeaderCallback = (Rect rect) => {
			EditorGUI.LabelField(rect, "Resource types");
		};
	}

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		list.DoLayoutList();
		
		serializedObject.ApplyModifiedProperties();
	}
}
