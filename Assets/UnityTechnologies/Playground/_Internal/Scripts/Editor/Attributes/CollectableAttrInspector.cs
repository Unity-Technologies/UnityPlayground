using Playground.Attributes;
using Playground.Editor.BaseClasses;
using UnityEditor;
using UnityEngine;

namespace Playground.Editor.Attributes
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(CollectableAttribute))]
    public class CollectableAttrInspector : InspectorBase
    {
        private readonly string explanation =
            "When the Player touches this object, it will be awarded one or more points.";

        public override void OnInspectorGUI()
        {
            GUILayout.Space(10);
            EditorGUILayout.HelpBox(explanation, MessageType.Info);

            base.OnInspectorGUI();

            CheckIfTrigger(true);
        }
    }
}