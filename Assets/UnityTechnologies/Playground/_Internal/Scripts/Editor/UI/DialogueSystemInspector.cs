using Playground.Editor.BaseClasses;
using Playground.UserInterface;
using UnityEditor;
using UnityEngine;

namespace Playground.Editor.UI
{
    [CustomEditor(typeof(DialogueSystem))]
    public class DialogueSystemInspector : InspectorBase
    {
        private readonly string explanation =
            "This script is responsible of creating dialogue balloons. Create dialogues by using DialogueBalloonAction in Conditions.";

        public override void OnInspectorGUI()
        {
            GUILayout.Space(10);
            EditorGUILayout.HelpBox(explanation, MessageType.Info);
        }
    }
}