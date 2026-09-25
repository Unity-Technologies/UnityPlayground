using System;
using System.Linq;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using ConditionBase = Playground.BaseClasses.ConditionBase;
using GameplayAction = Playground.BaseClasses.Action;

namespace Playground.Editor.BaseClasses
{
    [CanEditMultipleObjects]
    public class ConditionInspectorBase : InspectorBase
    {
        protected string chosenTag;
        protected bool filterByTag;

        protected ReorderableList list;


        protected void OnEnable()
        {
            list = new ReorderableList(serializedObject, serializedObject.FindProperty("actions"), true, true, true,
                true);

            //called for every element that has to be drawn in the ReorderableList
            list.drawElementCallback = (rect, index, isActive, isFocused) =>
            {
                SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);
                rect.y += 2;
                Rect r = new(rect.x, rect.y, rect.width - 20, EditorGUIUtility.singleLineHeight);
                EditorGUI.PropertyField(r, element, GUIContent.none, false);

                /*
            TODO: would be great to have but doesn't work for now
            //Add button at the end to unlink the Action?
            Rect buttonRect = new Rect(rect.width + 7, rect.y, 25, EditorGUIUtility.singleLineHeight);
            bool b = GUI.Button(buttonRect, "-");
            if(b)
            {
                //RemoveElement(index);
            }
            */
            };


            //draws the header of the ReorderableList
            list.drawHeaderCallback = rect => { EditorGUI.LabelField(rect, "Gameplay Actions"); };

            list.onAddDropdownCallback = (buttonRect, l) =>
            {
                GenericMenu menu = new();
                // List every concrete Action in the project
                foreach (Type actionType in TypeCache.GetTypesDerivedFrom<GameplayAction>()
                             .Where(t => !t.IsAbstract)
                             .OrderBy(t => t.Name))
                    menu.AddItem(new GUIContent(actionType.Name), false, ClickHandler, actionType);

                menu.AddItem(new GUIContent("- Empty slot -"), false, ClickHandler, null);
                menu.ShowAsContext();
            };

            list.onRemoveCallback += RemoveElement;
        }

        // Removes the selected slot from every selected Condition, and destroys the Action it pointed to
        private void RemoveElement(ReorderableList l)
        {
            int index = l.index;
            Undo.SetCurrentGroupName("Remove Action");
            int undoGroup = Undo.GetCurrentGroup();

            foreach (ConditionBase condition in targets)
            {
                SerializedObject conditionObject = new(condition);
                SerializedProperty actions = conditionObject.FindProperty("actions");
                if (index < 0 || index >= actions.arraySize) continue;

                SerializedProperty element = actions.GetArrayElementAtIndex(index);
                Component action = element.objectReferenceValue as Component;

                // Remove the slot first, so that Undo brings back both the component and the link to it
                element.objectReferenceValue = null;
                actions.DeleteArrayElementAtIndex(index);
                conditionObject.ApplyModifiedProperties();

                // Only destroy the Action if it's on this Condition's GameObject, otherwise it's just unlinked
                if (action != null
                    && action.gameObject == condition.gameObject)
                    Undo.DestroyObjectImmediate(action);
            }

            Undo.CollapseUndoOperations(undoGroup);
            serializedObject.Update();
            l.index = Mathf.Min(index, l.serializedProperty.arraySize - 1);
        }

        // Adds the chosen Action (or an empty slot, if actionType is null) to every selected Condition
        public void ClickHandler(object actionType)
        {
            Undo.SetCurrentGroupName("Add Action");
            int undoGroup = Undo.GetCurrentGroup();

            foreach (ConditionBase condition in targets)
            {
                //Assign the new Component
                Component newComponent = actionType is Type t ? Undo.AddComponent(condition.gameObject, t) : null;

                //Add the list element, and connect the newly assigned component to it
                SerializedObject conditionObject = new(condition);
                SerializedProperty actions = conditionObject.FindProperty("actions");
                actions.arraySize++;
                actions.GetArrayElementAtIndex(actions.arraySize - 1).objectReferenceValue = newComponent;
                conditionObject.ApplyModifiedProperties();
            }

            Undo.CollapseUndoOperations(undoGroup);
            serializedObject.Update();
            list.index = list.serializedProperty.arraySize - 1;
        }

        //draws the list ReorderableList of GameplayActions, the useCustomActions toggle and (if this is enabled) the default list of UnityEvents
        protected void DrawActionLists()
        {
            list.DoLayoutList();

            bool useCustom = EditorGUILayout.Toggle("Use custom actions",
                serializedObject.FindProperty("useCustomActions").boolValue);
            if (useCustom) EditorGUILayout.PropertyField(serializedObject.FindProperty("customActions"));
            serializedObject.FindProperty("useCustomActions").boolValue = useCustom;
        }


        //draws the tags as a dropdown only if the Filter by Tag toggle is enabled
        protected void DrawTagsGroup()
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("happenOnlyOnce"));
            filterByTag =
                EditorGUILayout.Toggle("Filter by Tag", serializedObject.FindProperty("filterByTag").boolValue);
            if (filterByTag) chosenTag = EditorGUILayout.TagField("Tag to check for", chosenTag);
            serializedObject.FindProperty("filterByTag").boolValue = filterByTag;
        }
    }
}