using UnityEditor;
using UnityEditor.Build;
using UnityEngine;

namespace Playground.Editor
{
    public class MenuItemFunctions
    {
        private const string FirstSetupKey = "FirstSetup";
        private const string PlaygroundState = "PlaygroundState";
        private const string PlaygroundCustomInspectors = "Playground/Custom Inspectors";

        private static readonly string[] defineSymbols =
        {
            "GAMEOBJECT_HEADER",
            "DEFAULT_INSPECTORS",
            "CUSTOM_INSPECTORS"
        };

        [InitializeOnLoadMethod]
        private static void Init()
        {
            if (SessionState.GetBool(FirstSetupKey, false)) return;
            
            TogglePlayground();
            SessionState.SetBool(FirstSetupKey, true);
        }
        
        [MenuItem(PlaygroundCustomInspectors)]
        public static void TogglePlayground()
        {
            bool playgroundOn = SessionState.GetBool(PlaygroundState, false);
            playgroundOn = !playgroundOn;

            if (playgroundOn)
                PlayerSettings.SetScriptingDefineSymbols(NamedBuildTarget.Standalone, defineSymbols);
            else
                PlayerSettings.SetScriptingDefineSymbols(NamedBuildTarget.Standalone, "");

            SessionState.SetBool(PlaygroundState, playgroundOn);
            Menu.SetChecked(PlaygroundCustomInspectors, playgroundOn);
        }
    }
}