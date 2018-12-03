using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(ConditionCollision))]
public class ConditionCollisionInspector : ConditionInspectorBase
{
	private string explanation = "Use this script to perform an action when this GameObject collides with another.";

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		chosenTag = serializedObject.FindProperty("filterTag").stringValue;

		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		GUILayout.Space(10);
		DrawTagsGroup();

		GUILayout.Space(10);
		DrawActionLists();

		CheckIfTrigger(false);

		if (GUI.changed)
		{
			serializedObject.FindProperty("filterTag").stringValue = chosenTag;
			serializedObject.ApplyModifiedProperties();
		}
	}
}