using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(CameraFollow))]
public class CameraFollowInspector : InspectorBase
{
	private string explanation = "This script makes the Camera follow a specific object (usually the Player).";
	private string warning = "WARNING: No object is selected, so the Camera won't move.";
	private string requiresCamera = "This script requires a Camera component to work. Add it to the Camera GameObject.";

	private GameObject go;

	private void OnEnable()
	{
		go = (target as CameraFollow).gameObject;
	}

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		//search for a Camera component
		Camera cam = go.GetComponent<Camera>();
		if(cam == null)
		{
			//display a warning and a button to fix it
			EditorGUILayout.HelpBox(requiresCamera, MessageType.Error);
		}
		else
		{
			//draw normal inspector
			base.OnInspectorGUI();

			if(!CheckIfAssigned("target", false))
			{
				EditorGUILayout.HelpBox(warning, MessageType.Warning);
			}
		}
	}
}
