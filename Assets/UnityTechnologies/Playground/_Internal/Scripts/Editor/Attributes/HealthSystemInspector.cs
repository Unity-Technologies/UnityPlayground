using Playground.Attributes;
using Playground.Editor.BaseClasses;
using UnityEditor;
using UnityEngine;

namespace Playground.Editor.Attributes
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(HealthSystemAttribute))]
    public class PlayerHealthInspector : InspectorBase
    {
        private readonly string explanation = "This scripts allows the Players or other objects to receive damage.";

        public override void OnInspectorGUI()
        {
            GUILayout.Space(10);
            EditorGUILayout.HelpBox(explanation, MessageType.Info);

            base.OnInspectorGUI();
        }
    }
}