using Playground.Attributes;
using Playground.Editor.BaseClasses;
using UnityEditor;
using UnityEngine;

namespace Playground.Editor.Attributes
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(DestroyForPointsAttribute))]
    public class DestroyForPointsAttrInspector : InspectorBase
    {
        private readonly string explanation = "When this object is destroyed, the player gets one or more points.";

        public override void OnInspectorGUI()
        {
            GUILayout.Space(10);
            EditorGUILayout.HelpBox(explanation, MessageType.Info);

            base.OnInspectorGUI();
        }
    }
}