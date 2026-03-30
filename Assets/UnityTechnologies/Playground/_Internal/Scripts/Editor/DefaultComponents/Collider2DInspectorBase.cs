using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Playground.Editor.DefaultComponents
{
    public class Collider2DInspectorBase : UnityEditor.Editor
    {
        protected readonly string triggerTooltip = "A Collider marked as \"Trigger\" is a special type of collider that can't be touched by other things, but it still detects if another GameObject enters it.\nUseful for Area Condition scripts.";

        protected Foldout CreateFoldout(string[] propNames)
        {
            Foldout extrasFoldout = new()
            {
                text = "Extra Options",
                viewDataKey = "Collider2DExtraOptions"
            };
            
            foreach (string propName in propNames)
            {
                extrasFoldout.Add(new PropertyField(serializedObject.FindProperty(propName)));
            }

            return extrasFoldout;
        }

        protected IMGUIContainer CreateEditColliderControls()
        {
            IMGUIContainer imguiContainer = new();
            imguiContainer.onGUIHandler += () =>
            {
                EditorGUILayout.Space(2f);
                EditorGUILayout.EditorToolbarForTarget(new GUIContent("Edit Collider"), target);
                EditorGUILayout.Space(2f);
            };
            
            return imguiContainer;
        }
    }
}