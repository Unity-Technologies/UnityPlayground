using Playground.Editor.BaseClasses;
using Playground.Gameplay;
using UnityEditor;
using UnityEngine;

namespace Playground.Editor.Gameplay
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(PickUpAndHold))]
    public class PickUpAndHoldInspector : InspectorBase
    {
        private readonly string explanation = "The Player can pick up and drop objects by pressing a key.";
        private readonly string warning = "The Pickup object must be tagged 'Pickup' and have component Rigidbody2D";

        public override void OnInspectorGUI()
        {
            GUILayout.Space(10);
            EditorGUILayout.HelpBox(explanation, MessageType.Info);
            GUILayout.Space(10);
            base.OnInspectorGUI();
            GUILayout.Space(10);
            EditorGUILayout.HelpBox(warning, MessageType.Warning);
        }
    }
}