using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(MoveWithArrows))]
public class MoveWithArrowsInspector : BaseInspectorWindow
{
	private string explanation = "The gameObject moves at the pression of some keys. Choose between Arrows or WASD.";
	private string constraintsReminder = "If you want, you can constrain movement on the X/Y axes in the Rigidbody2D's properties.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();

		if(so.FindProperty("movementType").intValue != 0)
		{
			EditorGUILayout.HelpBox(constraintsReminder, MessageType.Info);
		}
	}
}