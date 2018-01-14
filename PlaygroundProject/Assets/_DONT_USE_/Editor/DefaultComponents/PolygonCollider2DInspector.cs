using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CanEditMultipleObjects]
[CustomEditor(typeof(PolygonCollider2D))]
public class PolygonCollider2DInspector : Editor
{
	private bool showExtras = false, showTriggerExplanation = false;
	private string triggerMessage = "A Collider marked as \"Trigger\" is a special type of collider that can't be touched by other things, but it still detects if another GameObject enters it.\nUseful for Area Condition scripts.";

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		EditorGUILayout.Separator();

		EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Material"));

		showExtras = EditorGUILayout.Foldout(showExtras, new GUIContent("Extra Options"));
		if(showExtras)
		{
			EditorGUILayout.PropertyField(serializedObject.FindProperty("m_UsedByEffector"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("m_UsedByComposite"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Density"));
		}
		EditorGUILayout.Separator();

		EditorGUILayout.LabelField("Trigger", EditorStyles.boldLabel);
		EditorGUILayout.PropertyField(serializedObject.FindProperty("m_IsTrigger"));
		showTriggerExplanation = EditorGUILayout.Foldout(showTriggerExplanation, new GUIContent("More info"));
		if(showTriggerExplanation)
		{
			EditorGUILayout.HelpBox(triggerMessage, MessageType.Info, true);
		}

		serializedObject.ApplyModifiedProperties();
	}

	/*
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
