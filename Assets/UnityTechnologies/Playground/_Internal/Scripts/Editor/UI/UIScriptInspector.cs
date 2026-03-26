using Playground.Editor.BaseClasses;
using Playground.UserInterface;
using UnityEditor;
using UnityEngine;

namespace Playground.Editor.UI
{
    [CustomEditor(typeof(UIScript))]
    public class UIScriptInspector : InspectorBase
    {
        private readonly string explanation = "Use the UI to visualise points and health for the players.";
        private readonly string lifeReminder = "Don't forget to use the script HealthSystemAttribute on the player(s)!";
        private readonly string[] readableGameTypesEnum = { "Score", "Life", "Endless" };
        private readonly string[] readablePlayerEnum = { "One player", "Two players" };

        private int nOfPlayers, gameType;

        public override void OnInspectorGUI()
        {
            GUILayout.Space(10);
            EditorGUILayout.HelpBox(explanation, MessageType.Info);

            nOfPlayers = serializedObject.FindProperty("numberOfPlayers").intValue;
            gameType = serializedObject.FindProperty("gameType").intValue;

            nOfPlayers = EditorGUILayout.Popup("Number of players", nOfPlayers, readablePlayerEnum);

            gameType = EditorGUILayout.Popup("Game type", gameType, readableGameTypesEnum);
            if (gameType == 0) //score game
                EditorGUILayout.PropertyField(serializedObject.FindProperty("scoreToWin"));

            if (gameType == 1) //life
                EditorGUILayout.HelpBox(lifeReminder, MessageType.Info);

            //write all the properties back
            serializedObject.FindProperty("gameType").intValue = gameType;
            serializedObject.FindProperty("numberOfPlayers").intValue = nOfPlayers;

            if (GUI.changed) serializedObject.ApplyModifiedProperties();
        }
    }
}