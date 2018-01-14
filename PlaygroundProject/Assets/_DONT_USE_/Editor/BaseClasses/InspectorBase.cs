using UnityEngine;
using System.Collections;
using UnityEditor;

public class InspectorBase : Editor
{
	private SerializedProperty prop;

	private string prefabNotSceneHint = "WARNING: Select a Prefab from Project panel, not an object in the Hierarchy!";
	private string selectPrefabHint = "WARNING: No Prefab selected!";
	private string colliderWarning = "WARNING: You need to make sure the associated Collider2D has the \"Is Trigger\" option disabled for this script to work!";
	private string triggerWarning = "WARNING: You need to make sure the associated Collider2D has the \"Is Trigger\" option enabled for this script to work!";

	// Draws the regular Inspector with all the properties, but minus the Script field, for more clarity
	public void DrawDefaultInspectorMinusScript()
	{
		DrawPropertiesExcluding(serializedObject, "m_Script");
	}


	// Shows a warning box that enforces the selection of a Prefab, and not a GameObject
	// Used when the script won't work without a prefab
	protected bool ShowPrefabWarning(string propertyName)
	{
		GameObject go = serializedObject.FindProperty(propertyName).objectReferenceValue as GameObject;
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


	// Checks if a GameObject or Transform field has been assigned
	// Used usually when there is an optional field
	protected bool CheckIfAssigned(string propertyName, bool checkIfPrefab = true)
	{
		Object genericObject = serializedObject.FindProperty(propertyName).objectReferenceValue;
		if(genericObject != null)
		{
			GameObject go = genericObject as GameObject;
			if(checkIfPrefab)
			{
				//if scene.name is Null, then the GameObject is coming from the Project and is probably a prefab
				if(!string.IsNullOrEmpty(go.scene.name))
				{
					EditorGUILayout.HelpBox(prefabNotSceneHint, MessageType.Warning);
				}
			}
			return true;
		}
		else
		{
			// Message is printed externally
			return false;
		}
	}


	// Checks if an obects (usually an assigned prefab) uses a specific component
	protected bool CheckIfObjectUsesComponent<T>(string propertyName)
	{
		GameObject go = serializedObject.FindProperty(propertyName).objectReferenceValue as GameObject;
		T c = go.GetComponent<T>();

		return !c.Equals(null);
	}


	// Checks if the object is tagged with a specific tag
	protected bool CheckIfTaggedAs(string tagNeeded)
	{
		GameObject go = ((MonoBehaviour)target).gameObject;

		return go.CompareTag(tagNeeded);
	}


	// Checks if the Collider2D of an object is or is not a trigger, and outputs a message
	protected bool CheckIfTrigger(bool isTriggerNeeded)
	{
		bool isTrigger = (target as MonoBehaviour).GetComponent<Collider2D>().isTrigger;

		if(isTriggerNeeded && !isTrigger)
		{
			EditorGUILayout.HelpBox(triggerWarning, MessageType.Warning);
		}

		if(!isTriggerNeeded && isTrigger)
		{
			EditorGUILayout.HelpBox(colliderWarning, MessageType.Warning);
		}

		return isTrigger;
	}


	// Regular Inspector drawing and property saving
	override public void OnInspectorGUI()
	{
		DrawDefaultInspectorMinusScript();

		if (GUI.changed)
		{
			serializedObject.ApplyModifiedProperties();
		}
	}
}
