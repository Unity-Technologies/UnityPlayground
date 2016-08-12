using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UIScript))]
public class UIScriptInspector : BaseInspectorWindow
{
	private string explanation = "Use the UI to visualise points and health for the players.";
	private string lifeReminder = "Don't forget to use the script Player Health on the player(s)!";

	private int nOfPlayers = 0, gameType = 0;
	private string[] readablePlayerEnum = new string[]{"One player", "Two players"};
	private string[] readableGameTypesEnum = new string[]{"Score", "Life", "Endless"};

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		nOfPlayers = so.FindProperty("numberOfPlayers").intValue;
		gameType = so.FindProperty("gameType").intValue;

		nOfPlayers = EditorGUILayout.Popup("Number of players", nOfPlayers, readablePlayerEnum);

		gameType = EditorGUILayout.Popup("Game type", gameType, readableGameTypesEnum);
		if(gameType == 0) //score game
		{
			EditorGUILayout.PropertyField(so.FindProperty("scoreToWin"));
		}

		if(gameType == 1) //life
		{
			EditorGUILayout.HelpBox(lifeReminder, MessageType.Info);
		}

		//write all the properties back
		so.FindProperty("gameType").intValue = gameType;
		so.FindProperty("numberOfPlayers").intValue = nOfPlayers;

		if(GUI.changed)
		{
			so.ApplyModifiedProperties();
		}
	}
}
