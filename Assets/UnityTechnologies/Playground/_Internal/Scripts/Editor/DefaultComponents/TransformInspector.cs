using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

#if DEFAULT_INSPECTORS
namespace Playground.Editor.DefaultComponents
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(Transform))]
    public class TransformInspector : UnityEditor.Editor
    {
        private static readonly Color RedColor = new(0.8f, 0.2f, 0.2f);
        private static readonly Color GreenColor = new(0.2f, 0.7f, 0.2f);
        private static readonly Color BlueColor = new(0.2f, 0.4f, 0.9f);
        private static readonly Color PrefabBlue = new(0.2f, 0.64f, 0.88f);

        public override VisualElement CreateInspectorGUI()
        {
            VisualElement container = new();

            SerializedProperty posProp = serializedObject.FindProperty("m_LocalPosition");
            SerializedProperty rotProp = serializedObject.FindProperty("m_LocalRotation");
            SerializedProperty scaleProp = serializedObject.FindProperty("m_LocalScale");

            container.Add(BuildRow("Position", posProp, new[]
            {
                ("X", "x", RedColor),
                ("Y", "y", GreenColor)
            }, () =>
            {
                posProp.FindPropertyRelative("x").floatValue = 0f;
                posProp.FindPropertyRelative("y").floatValue = 0f;
            }, "0"));

            container.Add(BuildRotationRow(rotProp));

            container.Add(BuildRow("Scale", scaleProp, new[]
            {
                ("X", "x", RedColor),
                ("Y", "y", GreenColor)
            }, () =>
            {
                scaleProp.FindPropertyRelative("x").floatValue = 1f;
                scaleProp.FindPropertyRelative("y").floatValue = 1f;
            }, "1"));

            return container;
        }

        private VisualElement BuildRow(string label, SerializedProperty parentProp,
            (string label, string relative, Color color)[] fields, Action onReset, string resetText)
        {
            VisualElement wrapper = new();
            wrapper.AddToClassList("unity-base-field");
            wrapper.AddToClassList("unity-base-field__aligned");
            wrapper.style.flexDirection = FlexDirection.Row;
            wrapper.style.alignItems = Align.Center;
            wrapper.style.marginTop = 1;
            wrapper.style.marginBottom = 1;

            Label rowLabel = new(label);
            rowLabel.AddToClassList("unity-base-field__label");
            wrapper.Add(rowLabel);

            VisualElement fieldsContainer = new()
            {
                style =
                {
                    flexDirection = FlexDirection.Row,
                    flexGrow = 1,
                    alignItems = Align.Center
                }
            };

            foreach ((string fieldLabel, string relative, Color color) in fields)
            {
                SerializedProperty prop = parentProp.FindPropertyRelative(relative);

                FloatField floatField = new(fieldLabel)
                {
                    bindingPath = prop.propertyPath,
                    style =
                    {
                        flexGrow = 1,
                        flexBasis = 0,
                        marginLeft = 4
                    }
                };

                floatField.RegisterCallback<GeometryChangedEvent>(_ => StyleAxisLabel(floatField, color));

                fieldsContainer.Add(floatField);
            }

            Button resetBtn = new(() =>
            {
                serializedObject.Update();
                onReset();
                serializedObject.ApplyModifiedProperties();
            })
            {
                text = resetText,
                style = { width = 30, height = 18, marginLeft = 4, flexShrink = 0 }
            };
            fieldsContainer.Add(resetBtn);

            wrapper.Add(fieldsContainer);

            UpdatePrefabStyle(wrapper, rowLabel, parentProp);
            wrapper.TrackPropertyValue(parentProp, p => UpdatePrefabStyle(wrapper, rowLabel, p));

            AddPrefabContextMenu(wrapper, parentProp);
            return wrapper;
        }

        private VisualElement BuildRotationRow(SerializedProperty rotProp)
        {
            VisualElement wrapper = new();
            wrapper.AddToClassList("unity-base-field");
            wrapper.AddToClassList("unity-base-field__aligned");
            wrapper.style.flexDirection = FlexDirection.Row;
            wrapper.style.alignItems = Align.Center;
            wrapper.style.marginTop = 1;
            wrapper.style.marginBottom = 1;
            wrapper.style.borderLeftWidth = 2;
            wrapper.style.paddingLeft = 16;
            wrapper.style.marginLeft = -15;

            Label rowLabel = new("Rotation");
            rowLabel.AddToClassList("unity-base-field__label");
            wrapper.Add(rowLabel);

            VisualElement fieldsContainer = new()
            {
                style =
                {
                    flexDirection = FlexDirection.Row,
                    flexGrow = 1,
                    alignItems = Align.Center
                }
            };

            FloatField zRotField = new("Z")
            {
                style =
                {
                    flexGrow = 1,
                    flexBasis = 0,
                    marginLeft = 4
                }
            };

            zRotField.RegisterCallback<GeometryChangedEvent>(_ => StyleAxisLabel(zRotField, BlueColor));

            Action<SerializedProperty> updateRotField = p =>
            {
                zRotField.SetValueWithoutNotify(p.quaternionValue.eulerAngles.z);
            };

            zRotField.TrackPropertyValue(rotProp, updateRotField);
            zRotField.RegisterCallback<AttachToPanelEvent>(_ =>
            {
                rotProp.serializedObject.Update();
                updateRotField(rotProp);
            });

            zRotField.RegisterValueChangedCallback(evt =>
            {
                serializedObject.Update();
                Vector3 euler = rotProp.quaternionValue.eulerAngles;
                euler.z = evt.newValue;
                rotProp.quaternionValue = Quaternion.Euler(euler);
                serializedObject.ApplyModifiedProperties();
            });

            fieldsContainer.Add(zRotField);

            Button resetBtn = new(() =>
            {
                serializedObject.Update();
                rotProp.quaternionValue = Quaternion.identity;
                serializedObject.ApplyModifiedProperties();
            })
            {
                text = "0",
                style = { width = 30, height = 18, marginLeft = 4, flexShrink = 0 }
            };
            fieldsContainer.Add(resetBtn);

            wrapper.Add(fieldsContainer);

            UpdatePrefabStyle(wrapper, rowLabel, rotProp);
            wrapper.TrackPropertyValue(rotProp, p => UpdatePrefabStyle(wrapper, rowLabel, p));

            AddPrefabContextMenu(wrapper, rotProp);
            return wrapper;
        }

        private static bool HasAnyOverride(SerializedProperty prop)
        {
            if (prop.prefabOverride) return true;
            SerializedProperty iter = prop.Copy();
            SerializedProperty end = prop.GetEndProperty();
            while (iter.Next(true) && !SerializedProperty.EqualContents(iter, end))
                if (iter.prefabOverride)
                    return true;
            return false;
        }

        private static void UpdatePrefabStyle(VisualElement wrapper, Label rowLabel, SerializedProperty prop)
        {
            bool overridden = HasAnyOverride(prop);

            rowLabel.style.unityFontStyleAndWeight = overridden ? FontStyle.Bold : FontStyle.Normal;
            wrapper.style.borderLeftColor = overridden ? PrefabBlue : Color.clear;

            UQueryState<TextElement> inputFields = wrapper
                .Query<TextElement>(className: "unity-text-element--inner-input-field-component").Build();
            foreach (TextElement field in inputFields)
                field.style.unityFontStyleAndWeight = overridden ? FontStyle.Bold : FontStyle.Normal;
        }

        private static void StyleAxisLabel(FloatField field, Color color)
        {
            Label label = field.Q<Label>(className: "unity-base-field__label");
            if (label == null) return;

            label.style.backgroundColor = color;
            label.style.color = new Color(0.9f, 0.9f, 0.9f);
            label.style.unityFontStyleAndWeight = FontStyle.Bold;
            label.style.unityTextAlign = TextAnchor.MiddleCenter;
            label.style.minWidth = 18;
            label.style.maxWidth = 18;
            label.style.height = 18;
            label.style.fontSize = 11;
            label.style.borderTopLeftRadius = 2;
            label.style.borderTopRightRadius = 2;
            label.style.borderBottomLeftRadius = 2;
            label.style.borderBottomRightRadius = 2;
            label.style.paddingLeft = 0;
            label.style.paddingRight = 0;
            label.style.marginRight = 4;
        }

        private void AddPrefabContextMenu(VisualElement element, SerializedProperty prop)
        {
            element.AddManipulator(new ContextualMenuManipulator(evt =>
            {
                prop.serializedObject.Update();
                if (!HasAnyOverride(prop)) return;

                evt.menu.AppendAction("Revert", _ =>
                {
                    PrefabUtility.RevertPropertyOverride(prop, InteractionMode.UserAction);
                    SerializedProperty iter = prop.Copy();
                    SerializedProperty end = prop.GetEndProperty();
                    while (iter.Next(true) && !SerializedProperty.EqualContents(iter, end))
                        if (iter.prefabOverride)
                            PrefabUtility.RevertPropertyOverride(iter, InteractionMode.UserAction);
                    prop.serializedObject.Update();
                });

                Object targetObject = prop.serializedObject.targetObject;
                if (!PrefabUtility.IsPartOfImmutablePrefab(targetObject))
                    evt.menu.AppendAction("Apply to Prefab", _ =>
                    {
                        string assetPath = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(targetObject);
                        PrefabUtility.ApplyPropertyOverride(prop, assetPath, InteractionMode.UserAction);
                        SerializedProperty iter = prop.Copy();
                        SerializedProperty end = prop.GetEndProperty();
                        while (iter.Next(true) && !SerializedProperty.EqualContents(iter, end))
                            if (iter.prefabOverride)
                                PrefabUtility.ApplyPropertyOverride(iter, assetPath, InteractionMode.UserAction);
                        prop.serializedObject.Update();
                    });
            }));
        }
    }
}
#endif