using Playground.Editor.BaseClasses;
using Playground.Movement;
using UnityEditor;
using UnityEngine;

namespace Playground.Editor.Movement
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(Rotate))]
    public class RotateInspector : InspectorBase
    {
        private readonly string explanation = "The GameObject rotates when pressing the Arrow keys or WASD.";

        public override void OnInspectorGUI()
        {
            GUILayout.Space(10);
            EditorGUILayout.HelpBox(explanation, MessageType.Info);

            base.OnInspectorGUI();
        }
    }
}