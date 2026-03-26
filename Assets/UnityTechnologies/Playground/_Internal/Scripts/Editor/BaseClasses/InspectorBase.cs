using UnityEditor;
using UnityEngine;

namespace Playground.Editor.BaseClasses
{
    public class InspectorBase : UnityEditor.Editor
    {
        private readonly string colliderWarning = "Disable \"Is Trigger\" on the Collider to make this script work!";

        private readonly string prefabNotSceneHint =
            "Select a Prefab from Project panel, not an object in the Hierarchy!";

        private readonly int preWarningSpace = 5;
        private readonly string selectPrefabHint = "No Prefab selected!";
        private readonly string triggerWarning = "Enable \"Is Trigger\" on the Collider to make this script work!";
        private SerializedProperty prop;

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
            if (go != null)
            {
                //if scene.name is Null, then the GameObject is coming from the Project and is probably a prefab
                if (!string.IsNullOrEmpty(go.scene.name))
                {
                    GUILayout.Space(preWarningSpace);
                    EditorGUILayout.HelpBox(prefabNotSceneHint, MessageType.Warning);
                }

                return true;
            }

            GUILayout.Space(preWarningSpace);
            EditorGUILayout.HelpBox(selectPrefabHint, MessageType.Warning); //no prefab selected

            return false;
        }


        // Checks if a GameObject or Transform field has been assigned
        // Used usually when there is an optional field
        protected bool CheckIfAssigned(string propertyName, bool checkIfPrefab = true)
        {
            Object genericObject = serializedObject.FindProperty(propertyName).objectReferenceValue;
            if (genericObject != null)
            {
                GameObject go = genericObject as GameObject;
                if (checkIfPrefab)
                    //if scene.name is Null, then the GameObject is coming from the Project and is probably a prefab
                    if (!string.IsNullOrEmpty(go.scene.name))
                    {
                        GUILayout.Space(preWarningSpace);
                        EditorGUILayout.HelpBox(prefabNotSceneHint, MessageType.Warning);
                    }

                return true;
            }

            // Message is printed externally
            return false;
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

            if (isTriggerNeeded && !isTrigger)
            {
                GUILayout.Space(preWarningSpace);
                EditorGUILayout.HelpBox(triggerWarning, MessageType.Warning);
            }

            if (!isTriggerNeeded && isTrigger)
            {
                GUILayout.Space(preWarningSpace);
                EditorGUILayout.HelpBox(colliderWarning, MessageType.Warning);
            }

            return isTrigger;
        }


        // Regular Inspector drawing and property saving
        public override void OnInspectorGUI()
        {
            DrawDefaultInspectorMinusScript();

            if (GUI.changed) serializedObject.ApplyModifiedProperties();
        }
    }
}