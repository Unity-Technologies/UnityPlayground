using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if DEFAULT_INSPECTORS

[CanEditMultipleObjects]
[CustomEditor(typeof(Camera))]
public class CameraInspector : Editor
{
	private GameObject go;

	private void OnEnable()
	{
		go = (target as Camera).gameObject;

		//remove the FlareLayer component
		FlareLayer fl = go.GetComponent<FlareLayer>();
		if(fl != null)
		{
			DestroyImmediate(fl);
		}
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		EditorGUILayout.Separator();

		EditorGUILayout.PropertyField(serializedObject.FindProperty("m_BackGroundColor"), new GUIContent("Background Color"));
		EditorGUILayout.PropertyField(serializedObject.FindProperty("orthographic size"), new GUIContent("Frame Size"));
		EditorGUILayout.Separator();

		//check if Camera Follow script is already present
		if(go.GetComponent<CameraFollow>() != null)
		{
			GUI.enabled = false;
		}

		//button will be disabled if the script is already on this object
		if(GUILayout.Button("Add Camera Follow script"))
		{
			go.AddComponent<CameraFollow>();
		}

		GUI.enabled = true;

		serializedObject.ApplyModifiedProperties();
	}
	
}

#endif