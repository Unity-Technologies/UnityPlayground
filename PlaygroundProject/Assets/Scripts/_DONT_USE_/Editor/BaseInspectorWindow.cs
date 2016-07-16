using UnityEngine;
using System.Collections;
using UnityEditor;

public class BaseInspectorWindow : Editor
{
	protected SerializedObject so;
	private SerializedProperty prop;

	private string prefabNotSceneHint = "WARNING: Select a Prefab from Project panel, not an object in the Hierarchy!";
	private string selectPrefabHint = "WARNING: No Prefab selected!";

	void OnEnable()
	{
		so = new SerializedObject(target);
	}

	// Draws the regular Inspector with all the properties, but minus the Script field, for more clarity
	public void DrawDefaultInspectorMinusScript()
	{
		prop = so.GetIterator();
		while (prop.NextVisible(true))
		{
			if(prop.name != "m_Script")
			{
				//Debug.Log (prop.name);
				EditorGUILayout.PropertyField(prop);
			}
		}
	}


	// Shows a warning box that suggests to select a prefab, not a gameobject
	protected bool ShowObjectAsPrefabWarning(string propertyName)
	{
		// Extra warning message to try to catch if the kid uses an object in the scene
		GameObject go = so.FindProperty(propertyName).objectReferenceValue as GameObject;
		if(go != null)
		{
			//if scene.name is Null, then the GameObject is coming from the Project and is probably a prefab
			if(!string.IsNullOrEmpty(go.scene.name))
			{
				EditorGUILayout.HelpBox(prefabNotSceneHint, MessageType.Warning);
			}

			return true;
		}
		else
		{
			EditorGUILayout.HelpBox(selectPrefabHint, MessageType.Warning); //no prefab selected

			return false;
		}
	}

	protected bool CheckIfObjectUsesComponent<T>(string propertyName)
	{
		GameObject go = so.FindProperty(propertyName).objectReferenceValue as GameObject;
		T c = go.GetComponent<T>();

		return c == null;
	}

	// Regular Inspector drawing and property saving
	override public void OnInspectorGUI()
	{
		DrawDefaultInspectorMinusScript();

		if (GUI.changed)
		{
			so.ApplyModifiedProperties();
		}
	}
}
