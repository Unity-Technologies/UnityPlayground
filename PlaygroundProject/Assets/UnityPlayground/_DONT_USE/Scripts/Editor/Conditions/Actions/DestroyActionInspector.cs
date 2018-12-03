using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(DestroyAction))]
public class DestroyActionInspector : InspectorBase
{
	private string explanation = "Destroys a GameObject instantaneously on impact. Could be this object, or the one that suffered the impact.";
	private string tip = "TIP: You can assign a death effect, such as an explosion or another particle system.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();

		if(!CheckIfAssigned("deathEffect", true))
		{
			EditorGUILayout.HelpBox(tip, MessageType.Info);
		}
	}
}
