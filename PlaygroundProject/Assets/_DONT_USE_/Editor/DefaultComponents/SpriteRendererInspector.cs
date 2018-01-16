using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CanEditMultipleObjects]
[CustomEditor(typeof(SpriteRenderer))]
public class SpriteRendererInspector : Editor
{
	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		EditorGUILayout.Separator();
		EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Sprite"));
		EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Color"));
		EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel("Flip");
			EditorGUIUtility.labelWidth = 12f;
			EditorGUILayout.PropertyField(serializedObject.FindProperty("m_FlipX"), new GUIContent("X"), GUILayout.ExpandWidth(false));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("m_FlipY"), new GUIContent("Y"), GUILayout.ExpandWidth(false));
			EditorGUIUtility.labelWidth = 0f;
		EditorGUILayout.EndHorizontal();
		EditorGUILayout.PropertyField(serializedObject.FindProperty("m_DrawMode"));

		EditorGUILayout.Separator();
		DrawSortingLayers();
		EditorGUILayout.PropertyField(serializedObject.FindProperty("m_MaskInteraction"));
		
		serializedObject.ApplyModifiedProperties();
	}


	//Code adapted from Nick Gravelyn's repo: https://github.com/nickgravelyn/UnityToolbag/tree/master/SortingLayer
	private void DrawSortingLayers()
	{
		// Get the renderer from the target object
		var renderer = (target as SpriteRenderer);

		var sortingLayerNames = SortingLayer.layers.Select(l => l.name).ToArray();

		// Look up the layer name using the current layer ID
		string oldName = SortingLayer.IDToName(renderer.sortingLayerID);

		// Use the name to look up our array index into the names list
		int oldLayerIndex = System.Array.IndexOf(sortingLayerNames, oldName);

		// Show the popup for the names
		int newLayerIndex = EditorGUILayout.Popup("Sorting Layer", oldLayerIndex, sortingLayerNames);

		// If the index changes, look up the ID for the new index to store as the new ID
		if (newLayerIndex != oldLayerIndex) {
			Undo.RecordObject(renderer, "Edit Sorting Layer");
			renderer.sortingLayerID = SortingLayer.NameToID(sortingLayerNames[newLayerIndex]);
			EditorUtility.SetDirty(renderer);
		}

		// Expose the manual sorting order
		int newSortingLayerOrder = EditorGUILayout.IntField("Order in Layer", renderer.sortingOrder);
		if (newSortingLayerOrder != renderer.sortingOrder) {
			Undo.RecordObject(renderer, "Edit Sorting Order");
			renderer.sortingOrder = newSortingLayerOrder;
			EditorUtility.SetDirty(renderer);
		}
	}
}
