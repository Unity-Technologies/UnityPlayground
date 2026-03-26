using Playground.Conditions;
using Playground.Editor.BaseClasses;
using UnityEditor;
using UnityEngine;

namespace Playground.Editor.Conditions
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ConditionRepeat))]
    public class ConditionRepeatInspector : ConditionInspectorBase
    {
        private readonly string explanation = "Use this script to perform an action repeatedly.";

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            GUILayout.Space(10);
            EditorGUILayout.HelpBox(explanation, MessageType.Info);

            GUILayout.Space(10);

            EditorGUILayout.PropertyField(serializedObject.FindProperty("initialDelay"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("frequency"));

            GUILayout.Space(10);
            DrawActionLists();

            serializedObject.ApplyModifiedProperties();
        }
    }
}