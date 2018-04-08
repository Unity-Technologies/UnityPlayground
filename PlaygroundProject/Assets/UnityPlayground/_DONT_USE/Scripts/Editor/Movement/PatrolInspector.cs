using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditorInternal;

[CanEditMultipleObjects]
[CustomEditor(typeof(Patrol))]
public class PatrolInspector : InspectorBase
{
	private string explanation = "The object moves through a series of positions. This can be used for patrolling characters.";

	private ReorderableList list;
	Patrol patrolScript;

	string arrayDataString = "waypoints.Array.data[{0}]";
	string arraySizeString = "waypoints.Array.size";

	private void OnEnable()
	{
		list = new ReorderableList(serializedObject, serializedObject.FindProperty("waypoints"), true, true, true, true);
		patrolScript = (Patrol)target;

		//called for every element that has to be drawn in the ReorderableList
		list.drawElementCallback =  
			(Rect rect, int index, bool isActive, bool isFocused) => {
			SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);
			rect.y += 2;
			Rect r = new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight);
			EditorGUI.PropertyField(r, element, GUIContent.none, false);

		};

		list.onAddCallback = (ReorderableList l) => {  
			var index = l.serializedProperty.arraySize;
			l.serializedProperty.arraySize++;
			l.index = index;
			var element = l.serializedProperty.GetArrayElementAtIndex(index);
			element.vector2Value = l.serializedProperty.GetArrayElementAtIndex(index-1).vector2Value + Vector2.one;
		};


		//draws the header of the ReorderableList
		list.drawHeaderCallback = (Rect rect) => {
			EditorGUI.LabelField(rect, "Stops");
		};
	}


	//Recover the array of Vector3s from the serializedObject's properties
	private Vector3[] GetWaypoints()
	{
		int arrayCount = serializedObject.FindProperty(arraySizeString).intValue;
		Vector3[] wpArray = new Vector3[arrayCount];

		for(int i=0; i<arrayCount; i++)
		{
			wpArray[i] = serializedObject.FindProperty(string.Format(arrayDataString, i)).vector3Value;
		}

		return wpArray;
	}


	private void SetWaypoint(int index, Vector3 values)
	{
		serializedObject.FindProperty(string.Format(arrayDataString, index)).vector3Value = values;
	}

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		EditorGUILayout.PropertyField(serializedObject.FindProperty("speed"));

		GUILayout.Space(5);
		EditorGUILayout.PropertyField(serializedObject.FindProperty("backToStart"));
		list.DoLayoutList();

		//Button to reset all waypoints
		EditorGUILayout.Space();
		if(GUILayout.Button("Reset Waypoints"))
		{
			patrolScript.Reset();
			EditorApplication.Beep();

			//force both the custom Inspector and the Scene View to show the changes
			Repaint();
			SceneView.RepaintAll();
		}
		
		GUILayout.Space(5);
		GUILayout.Label("Orientation", EditorStyles.boldLabel);
		bool orientToDirectionTemp = EditorGUILayout.Toggle("Orient to direction", serializedObject.FindProperty("orientToDirection").boolValue);
		if(orientToDirectionTemp)
		{
			EditorGUILayout.PropertyField(serializedObject.FindProperty("lookAxis"));
		}
		serializedObject.FindProperty("orientToDirection").boolValue = orientToDirectionTemp;

		serializedObject.ApplyModifiedProperties();
	}
	

	//Draw handle gizmos in the scene in Edit Mode to move waypoints around, little blue dots in Play Mode
	private void OnSceneGUI()
	{
		Vector3 lastPos = patrolScript.transform.position;
		Handles.color = new Color32(33,150,243,255);
		Vector3 orientation;
		
		for(int i=0; i<patrolScript.waypoints.Length; i++)
		{
			if(!Application.isPlaying)
			{
				EditorGUI.BeginChangeCheck();
				Vector3 gizmoPos = Handles.PositionHandle(patrolScript.waypoints[i], Quaternion.identity);
				
				orientation = (gizmoPos-lastPos).normalized;
				Handles.DrawDottedLine(lastPos, gizmoPos, 8f);
				Handles.ArrowHandleCap(0, gizmoPos-(orientation * 1.2f), Quaternion.LookRotation(orientation, -Vector3.forward) , 1f, EventType.Repaint);
			
				if(EditorGUI.EndChangeCheck())
				{
					patrolScript.waypoints[i] = gizmoPos;
					Repaint();
				}

				lastPos = gizmoPos;
			}
			else
			{
				Handles.DrawSolidDisc(patrolScript.waypoints[i], -Vector3.forward, .1f);
			}
		}

		if(patrolScript.backToStart
			&& !Application.isPlaying)
		{
			orientation = (patrolScript.transform.position-lastPos).normalized;
			Handles.DrawDottedLine(lastPos, patrolScript.transform.position, 8f);
			Handles.ArrowHandleCap(0, patrolScript.transform.position-(orientation * 2f), Quaternion.LookRotation(orientation, -Vector3.forward), 1f, EventType.Repaint);
		}
	}
}