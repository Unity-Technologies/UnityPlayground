using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameObject))]
public class TestScriptInspector : Editor {

	private GameObject gameObject;
	private string tag;
	private Texture2D headerBackground;

	public void OnEnable()
	{
		gameObject = (GameObject)target;

		headerBackground = Resources.Load<Texture2D>("Textures/MidGrey");
	}

	public override void OnInspectorGUI()
	{
		/*Component[] c;
		c = ((GameObject)target).GetComponents<Component>();
		foreach(Component comp in c)
		{
			//comp.hideFlags = HideFlags.HideInInspector;
		}


		fold = EditorGUILayout.InspectorTitlebar(fold, Selection.activeGameObject.transform.parent);
		if (fold)
		{

			
		}
		*/
	}

	protected override void OnHeaderGUI()
	{
		GUIStyle boxStyle = new GUIStyle();
		boxStyle.padding = new RectOffset(15, 5, 15, 10);
		boxStyle.normal.background = headerBackground;
		GUIStyle fontStyle = new GUIStyle(GUI.skin.textField);
		fontStyle.fontSize = 12;

		GUILayout.BeginVertical(boxStyle);

		GUILayout.BeginHorizontal();
		gameObject.SetActive(GUILayout.Toggle(gameObject.activeSelf, "", GUILayout.Width(25)));
		gameObject.name = EditorGUILayout.DelayedTextField(gameObject.name, fontStyle, GUILayout.Height(17));
		GUILayout.EndHorizontal();

		GUILayout.Space(5);

		GUILayout.BeginHorizontal();
		GUILayout.Label("Tag", GUILayout.ExpandWidth(false));
		gameObject.tag = EditorGUILayout.TagField(gameObject.tag);
		GUILayout.EndHorizontal();

		GUILayout.EndVertical();
	}
}
