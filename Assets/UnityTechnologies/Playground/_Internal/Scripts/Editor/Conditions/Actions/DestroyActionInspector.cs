using Playground.Conditions.Actions;
using Playground.Editor.BaseClasses;
using UnityEditor;
using UnityEngine;

namespace Playground.Editor.Conditions.Actions
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(DestroyAction))]
    public class DestroyActionInspector : InspectorBase
    {
        private readonly string explanation =
            "Destroys a GameObject instantaneously on impact. Could be this object, or the one that suffered the impact.";

        private readonly string tip =
            "TIP: You can assign a death effect, such as an explosion or another particle system.";

        public override void OnInspectorGUI()
        {
            GUILayout.Space(10);
            EditorGUILayout.HelpBox(explanation, MessageType.Info);

            base.OnInspectorGUI();

            if (!CheckIfAssigned("deathEffect")) EditorGUILayout.HelpBox(tip, MessageType.Info);
        }
    }
}