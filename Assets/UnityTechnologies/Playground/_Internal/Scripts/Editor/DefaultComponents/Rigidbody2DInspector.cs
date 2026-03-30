using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

#if DEFAULT_INSPECTORS
namespace Playground.Editor.DefaultComponents
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(Rigidbody2D))]
    public class Rigidbody2DInspector : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            VisualElement container = new();

            container.Add(new PropertyField(serializedObject.FindProperty("m_BodyType")));
            container.Add(new PropertyField(serializedObject.FindProperty("m_Mass")));
            container.Add(new PropertyField(serializedObject.FindProperty("m_LinearDamping")));
            container.Add(new PropertyField(serializedObject.FindProperty("m_AngularDamping")));
            container.Add(new PropertyField(serializedObject.FindProperty("m_GravityScale")));

            Foldout constraintsFoldout = new()
            {
                text = "Constraints",
                viewDataKey = "RB2DConstraints"
            };

            SerializedProperty constraintsProp = serializedObject.FindProperty("m_Constraints");

            var freezePosX = CreateConstraintToggle("Freeze Position X", constraintsProp, (int)RigidbodyConstraints2D.FreezePositionX);
            var freezePosY = CreateConstraintToggle("Freeze Position Y", constraintsProp, (int)RigidbodyConstraints2D.FreezePositionY);
            var freezeRot = CreateConstraintToggle("Freeze Rotation", constraintsProp, (int)RigidbodyConstraints2D.FreezeRotation);

            constraintsFoldout.Add(freezePosX);
            constraintsFoldout.Add(freezePosY);
            constraintsFoldout.Add(freezeRot);
            container.Add(constraintsFoldout);

            Foldout extrasFoldout = new()
            {
                text = "Extra Options",
                viewDataKey = "RB2DExtraOptions"
            };
            extrasFoldout.Add(new PropertyField(serializedObject.FindProperty("m_Material")));
            container.Add(extrasFoldout);

            return container;
        }
        
        private VisualElement CreateConstraintToggle(string label, SerializedProperty prop, int flagValue)
        {
            Toggle toggle = new(label)
            {
                style =
                {
                    borderLeftWidth = 2f,
                    paddingLeft = 16f,
                    marginLeft = -30f
                }
            };

            toggle.SetValueWithoutNotify((prop.intValue & flagValue) != 0);

            toggle.RegisterValueChangedCallback(evt =>
            {
                prop.serializedObject.Update();
                if (evt.newValue)
                    prop.intValue |= flagValue;
                else
                    prop.intValue &= ~flagValue;
                prop.serializedObject.ApplyModifiedProperties();
            });

            toggle.TrackPropertyValue(prop, p =>
            {
                toggle.SetValueWithoutNotify((p.intValue & flagValue) != 0);
                UpdateOverrideStyle(toggle, p);
            });

            toggle.RegisterCallback<AttachToPanelEvent>(_ =>
            {
                prop.serializedObject.Update();
                UpdateOverrideStyle(toggle, prop);
            });

            toggle.AddManipulator(new ContextualMenuManipulator(evt =>
            {
                prop.serializedObject.Update();

                Object targetObject = prop.serializedObject.targetObject;
                PropertyModification[] mods = PrefabUtility.GetPropertyModifications(targetObject);

                bool hasOverride = mods != null && mods.Any(m =>
                    m.propertyPath == prop.propertyPath &&
                    m.target == PrefabUtility.GetCorrespondingObjectFromSource(targetObject));

                if (hasOverride)
                {
                    if (!PrefabUtility.IsPartOfImmutablePrefab(targetObject))
                    {
                        evt.menu.AppendAction("Apply to Prefab", _ =>
                        {
                            string assetPath = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(targetObject);
                            PrefabUtility.ApplyPropertyOverride(prop, assetPath, InteractionMode.UserAction);
                            prop.serializedObject.Update();
                            toggle.SetValueWithoutNotify((prop.intValue & flagValue) != 0);
                            UpdateOverrideStyle(toggle, prop);
                        });
                    }
                    
                    evt.menu.AppendAction("Revert", _ =>
                    {
                        PrefabUtility.RevertPropertyOverride(prop, InteractionMode.UserAction);
                        prop.serializedObject.Update();
                        toggle.SetValueWithoutNotify((prop.intValue & flagValue) != 0);
                        UpdateOverrideStyle(toggle, prop);
                    });
                }
            }));

            return toggle;
        }
        
        private static void UpdateOverrideStyle(Toggle toggle, SerializedProperty prop)
        {
            Label labelElement = toggle.Q<Label>();

            if (prop.prefabOverride)
            {
                labelElement.style.unityFontStyleAndWeight = FontStyle.Bold;
                toggle.style.borderLeftColor = new Color(0.2f, 0.64f, 0.88f);
            }
            else
            {
                labelElement.style.unityFontStyleAndWeight = FontStyle.Normal;
                toggle.style.borderLeftColor = Color.clear;
            }
        }
    }
}

#endif