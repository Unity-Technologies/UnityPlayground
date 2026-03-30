using Playground.Movement;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

#if DEFAULT_INSPECTORS
namespace Playground.Editor.DefaultComponents
{
    [CustomEditor(typeof(UniversalAdditionalCameraData))]
    public class CameraInspector : UnityEditor.Editor
    {
        private Camera _targetCamera;
        private Button _addFollowBtn;
        private SerializedObject _cameraSerObj;

        public override VisualElement CreateInspectorGUI()
        {
            VisualElement fakeContainer = new();
            fakeContainer.RegisterCallbackOnce<AttachToPanelEvent>(Callback);
            return fakeContainer;
        }

        private void Callback(AttachToPanelEvent evt)
        {
            _targetCamera = ((UniversalAdditionalCameraData)target).gameObject.GetComponent<Camera>();
            
            InspectorElement cameraInspector = evt.destinationPanel.visualTree.Q<InspectorElement>("CameraInspector");
            cameraInspector.Clear();
            cameraInspector.ClearClassList();
            
            cameraInspector.AddToClassList("unity-inspector-element");
            cameraInspector.AddToClassList("unity-inspector-element--uie");
            cameraInspector.AddToClassList("unity-inspector-element--uie-custom");
            FillCameraInspector(cameraInspector);

            ((VisualElement)evt.currentTarget).parent.parent.RemoveFromHierarchy();
        }

        private void FillCameraInspector(VisualElement container)
        {
            _cameraSerObj = new SerializedObject(_targetCamera);

            // TODO: Allow to change orthographic > perspective?
            
            //container.Add(CreatePropertyField("orthographic"));
            container.Add(CreatePropertyField("orthographic size", "Frame Size"));
            //container.Add(CreatePropertyField("field of view"));
            
            container.Add(CreatePropertyField("m_BackGroundColor", "Background Color"));

            _addFollowBtn = new Button(() =>
            {
                if (_targetCamera.GetComponent<CameraFollow>() == null) Undo.AddComponent<CameraFollow>(_targetCamera.gameObject);
                _addFollowBtn.SetEnabled(false);
            })
            {
                text = "Add Camera Follow script",
                style = { height = 24f }
            };

            _addFollowBtn.SetEnabled(!_targetCamera.TryGetComponent<CameraFollow>(out _));

            container.Add(_addFollowBtn);
        }

        private VisualElement CreatePropertyField(string propertyName, string label = "")
        {
            SerializedProperty prop = _cameraSerObj.FindProperty(propertyName);
            if(label == "") label = prop.displayName;
            
            PropertyField propertyField = new();
            propertyField.label = label;
            propertyField.BindProperty(prop);
            
            return propertyField;
        }
    }
}
#endif