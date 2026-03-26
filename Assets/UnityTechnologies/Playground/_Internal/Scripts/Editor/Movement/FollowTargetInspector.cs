using Playground.Editor.BaseClasses;
using Playground.Movement;
using UnityEditor;
using UnityEngine;

namespace Playground.Editor.Movement
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(FollowTarget))]
    public class FollowTargetInspector : InspectorBase
    {
        private readonly string explanation = "This GameObject will pursue a target constantly.";

        public override void OnInspectorGUI()
        {
            GUILayout.Space(10);
            EditorGUILayout.HelpBox(explanation, MessageType.Info);

            GUILayout.Space(5);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("target"));

            //Draw custom inspector
            EditorGUILayout.PropertyField(serializedObject.FindProperty("speed"));

            GUILayout.Space(10);

            SerializedProperty lookAtTargetProperty = serializedObject.FindProperty("lookAtTarget");

            lookAtTargetProperty.boolValue =
                EditorGUILayout.BeginToggleGroup("Look at target", lookAtTargetProperty.boolValue);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("useSide"));
            EditorGUILayout.EndToggleGroup();

            if (GUI.changed) serializedObject.ApplyModifiedProperties();
        }
    }
}