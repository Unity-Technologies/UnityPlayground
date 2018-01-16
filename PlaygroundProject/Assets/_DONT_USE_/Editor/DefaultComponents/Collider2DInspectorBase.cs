using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Collider2DInspectorBase : Editor
{
	protected bool showExtras = false;
	protected string triggerMessage = "A Collider marked as \"Trigger\" is a special type of collider that can't be touched by other things, but it still detects if another GameObject enters it.\nUseful for Area Condition scripts.";

	protected void ShowExtrasBlock(string[] properties)
	{
		showExtras = EditorGUILayout.Foldout(showExtras, new GUIContent("Extra Options"));
		if(showExtras)
		{
			for(int i=0; i<properties.Length; i++)
			{
				EditorGUILayout.PropertyField(serializedObject.FindProperty(properties[i]));
			}
		}
	}

	protected void ShowExtrasBlock()
	{

	}

	/*
	//TODO
	private void EditMode()
	{
		var sel = Selection.activeGameObject;
		var col = sel.GetComponent<Collider2D>();
	
		if (!col)
			return;
	
		if (UnityEditorInternal.EditMode.editMode == UnityEditorInternal.EditMode.SceneViewEditMode.Collider)
		{
			UnityEditorInternal.EditMode.QuitEditMode();
		}
		else
		{
			UnityEditorInternal.EditMode.ChangeEditMode(UnityEditorInternal.EditMode.SceneViewEditMode.Collider, col.bounds, this);
		}
	
		Debug.Log("EditMode: " + UnityEditorInternal.EditMode.editMode);
	}
	*/
}
