using Playground.Editor.BaseClasses;
using Playground.Gameplay;
using UnityEditor;
using UnityEngine;

namespace Playground.Editor.Gameplay
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(TimedSelfDestruct))]
    public class TimedSelfDestructInspector : InspectorBase
    {
        private readonly string explanation =
            "This GameObject will self destruct after a set amount of time, useful for bullets so they don't accumulate.";

        public override void OnInspectorGUI()
        {
            GUILayout.Space(10);
            EditorGUILayout.HelpBox(explanation, MessageType.Info);

            base.OnInspectorGUI();
        }
    }
}