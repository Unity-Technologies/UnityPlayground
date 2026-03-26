using Playground.Editor.BaseClasses;
using Playground.Movement;
using UnityEditor;
using UnityEngine;

namespace Playground.Editor.Movement
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(AutoMove))]
    public class AutoMoveInspector : InspectorBase
    {
        private readonly string explanation = "The GameObject moves automatically in a specific direction.";

        public override void OnInspectorGUI()
        {
            GUILayout.Space(10);
            EditorGUILayout.HelpBox(explanation, MessageType.Info);

            base.OnInspectorGUI();
        }
    }
}