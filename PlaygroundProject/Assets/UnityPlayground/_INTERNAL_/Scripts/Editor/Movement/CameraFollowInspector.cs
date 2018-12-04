using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(CameraFollow))]
public class CameraFollowInspector : InspectorBase
{
	private string explanation = "This script makes the Camera follow a specific object (usually the Player).";
	private string warning = "WARNING: No object is selected, so the Camera will not move.";
	private string requiresCamera = "This script requires a Camera component to work. Add it to the Camera GameObject.";

    private string undoLimitBoundsMessage = "Change bounds";

	private GameObject go;

	private void OnEnable()
	{
		go = (target as CameraFollow).gameObject;
	}

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		//search for a Camera component
		Camera cam = go.GetComponent<Camera>();
		if(cam == null)
		{
			//display a warning and a button to fix it
			EditorGUILayout.HelpBox(requiresCamera, MessageType.Error);
		}
		else
		{
            EditorGUILayout.PropertyField(serializedObject.FindProperty("target"));

            if (!CheckIfAssigned("target", false))
			{
				EditorGUILayout.HelpBox(warning, MessageType.Warning);
			}

            GUILayout.Space(5);
            GUILayout.Label("Limits", EditorStyles.boldLabel);
            bool allowLimitBoundsTemp = EditorGUILayout.Toggle("Use Bounds", serializedObject.FindProperty("limitBounds").boolValue);
            if (allowLimitBoundsTemp) {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("left"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("right"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("bottom"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("top"));
            }
            serializedObject.FindProperty("limitBounds").boolValue = allowLimitBoundsTemp;

            serializedObject.ApplyModifiedProperties();
        }
	}

    private void OnSceneGUI() {
        CameraFollow followScript = target as CameraFollow;
        if (null == followScript) return;

        Handles.color = Color.yellow;
        if (followScript.limitBounds) {
            Vector3[] verts = new Vector3[4];
            verts[0] = new Vector3(followScript.left, followScript.bottom, 0f);
            verts[1] = new Vector3(followScript.right, followScript.bottom, 0f);
            verts[2] = new Vector3(followScript.right, followScript.top, 0f);
            verts[3] = new Vector3(followScript.left, followScript.top, 0f);
            Handles.DrawSolidRectangleWithOutline(verts, Color.clear, Color.yellow);

            float handleSize = 0.25f;
            Vector3 handleSnap = Vector3.one;
            Quaternion handleRotation = Quaternion.identity;
            Handles.CapFunction handleCapFunction = Handles.DotHandleCap;

            //Dot bottom left
            EditorGUI.BeginChangeCheck();
            Vector3 tmpBottomLeft = Handles.FreeMoveHandle(verts[0], handleRotation, handleSize, handleSnap, handleCapFunction);
            if (EditorGUI.EndChangeCheck()) {
                Undo.RecordObject(followScript, undoLimitBoundsMessage);
                followScript.left = tmpBottomLeft.x;
                followScript.bottom = tmpBottomLeft.y;
            }

            //Dot bottom right
            EditorGUI.BeginChangeCheck();
            Vector3 tmpBottomRight = Handles.FreeMoveHandle(verts[1], handleRotation, handleSize, handleSnap, handleCapFunction);
            if (EditorGUI.EndChangeCheck()) {
                Undo.RecordObject(followScript, undoLimitBoundsMessage);
                followScript.right = tmpBottomRight.x;
                followScript.bottom = tmpBottomRight.y;
            }

            //Dot top right
            EditorGUI.BeginChangeCheck();
            Vector3 tmpTopRight = Handles.FreeMoveHandle(verts[2], handleRotation, handleSize, handleSnap, handleCapFunction);
            if (EditorGUI.EndChangeCheck()) {
                Undo.RecordObject(followScript, undoLimitBoundsMessage);
                followScript.right = tmpTopRight.x;
                followScript.top = tmpTopRight.y;
            }

            //Dot top left
            EditorGUI.BeginChangeCheck();
            Vector3 tmpTopLeft = Handles.FreeMoveHandle(verts[3], handleRotation, handleSize, handleSnap, handleCapFunction);
            if (EditorGUI.EndChangeCheck()) {
                Undo.RecordObject(followScript, undoLimitBoundsMessage);
                followScript.left = tmpTopLeft.x;
                followScript.top = tmpTopLeft.y;
            }
        }
    }
}
