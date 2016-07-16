using UnityEngine;
using System.Collections;
using UnityEditor;

public class BaseInspectorWindow : Editor
{
	private SerializedObject so;
	private SerializedProperty prop;

	void OnEnable()
	{
		so = new SerializedObject(target);
	}

	public void DrawDefaultInspectorMinusScript()
	{
		prop = so.GetIterator();
		int i = 0;
		while (prop.NextVisible(true))
		{
			if(i != 0)
			{
				EditorGUILayout.PropertyField(prop);
			}
			i++;
		}
	}

	override public void OnInspectorGUI()
	{
		DrawDefaultInspectorMinusScript();

		if (GUI.changed)
		{
			so.ApplyModifiedProperties();
		}
	}
}
