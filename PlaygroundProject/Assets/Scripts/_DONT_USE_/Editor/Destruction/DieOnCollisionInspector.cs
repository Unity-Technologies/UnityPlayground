using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DieOnCollision))]
public class DieOnCollisionInspector : BaseInspectorWindow
{
	private string explanation = "This gameObject will be destroyed instantaneously on impact.";
	private string tip = "TIP: You can assign a death effect, such as an explosion or another particle system.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();

		if(!CheckIfAssigned("deathEffect"))
		{
			EditorGUILayout.HelpBox(tip, MessageType.Info);
		}
	}
}
