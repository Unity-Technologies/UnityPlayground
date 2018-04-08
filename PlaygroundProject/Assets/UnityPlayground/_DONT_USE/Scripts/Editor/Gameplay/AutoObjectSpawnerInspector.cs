using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(AutoObjectSpawner))]
public class AutoObjectSpawnerInspector : InspectorBase
{
	private string explanation = "Spawns an object repeatedly in a square area. The size of the area is defined by Minimum and Maximum, while Spawn Interval defines the delay of spawning.";
	
	public override void OnInspectorGUI()
	{
		GUILayout.Space (10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		ShowPrefabWarning("prefabToSpawn");

		base.OnInspectorGUI();
	}
}
