using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(AutoObjectSpawner))]
public class AutoObjectSpawnerInspector : BaseInspectorWindow
{
	private string explanation = "Spawns an object repeatedly in a square area. The size of the area is defined by Minimum and Maximum, while Spawn Interval defines the delay of spawning.";
	
	public override void OnInspectorGUI()
	{
		GUILayout.Space (10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		ShowPrefabWarning("prefabToSpawn");

		base.OnInspectorGUI();
	}

	// OnSceneGUI() commented due to a weird bug, needs investigation
	// srcAttach < m_CurrentFramebuffer.colorCount && "We should always resolve only current RT"
	public void TempName() //OnSceneGUI()
	{
		Vector2 pos = so.FindProperty ("transform.position").vector2Value;
		float hor = so.FindProperty ("horizontalSize").floatValue;
		float ver = so.FindProperty ("verticalSize").floatValue;
		Vector3[] vertices = new Vector3[]
		{
			new Vector3 (-hor + pos.x, -ver + pos.y, 0f),
			new Vector3 (-hor + pos.x, +ver + pos.y, 0f),
			new Vector3 (+hor + pos.x, +ver + pos.y, 0f),
			new Vector3 (+hor + pos.x, -ver + pos.y, 0f)
		};

		Handles.DrawSolidRectangleWithOutline(vertices, Color.red, Color.red);
	}
}
