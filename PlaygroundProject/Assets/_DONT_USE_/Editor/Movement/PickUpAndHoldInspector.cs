using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(PickUpAndHold))]
public class PickUpAndHoldInspector : BaseInspectorWindow
{
	private string explanation = "When this script is attached to the Player, the Player can pick up objects with 'b' and drop them with 'n'. The pickup object must be tagged 'Pickup'.";
	private string warning = "The Pickup object must have component Rigidbody2D";

	public override void OnInspectorGUI()
	{
		EditorGUILayout.HelpBox(explanation, MessageType.Info);
		EditorGUILayout.HelpBox(warning, MessageType.Info);

		base.OnInspectorGUI();
	}
}
