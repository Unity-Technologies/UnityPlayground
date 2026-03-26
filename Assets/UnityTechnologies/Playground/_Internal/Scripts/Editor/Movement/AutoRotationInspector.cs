using Playground.Editor.BaseClasses;
using Playground.Movement;
using UnityEditor;
using UnityEngine;

namespace Playground.Editor.Movement
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(AutoRotate))]
    public class AutoRotateInspector : InspectorBase
    {
        private readonly string explanation = "The GameObject rotates automatically.";
        private readonly string tip = "TIP: Use negative value to rotate in the other direction.";

        public override void OnInspectorGUI()
        {
            GUILayout.Space(10);
            EditorGUILayout.HelpBox(explanation, MessageType.Info);

            base.OnInspectorGUI();

            EditorGUILayout.HelpBox(tip, MessageType.Info);
        }
    }
}