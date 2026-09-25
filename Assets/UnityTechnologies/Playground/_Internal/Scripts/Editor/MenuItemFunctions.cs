using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Build;

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

        // Runs after every domain reload, including the one that follows a build target switch
        [InitializeOnLoadMethod]
        private static void Init()
        {
            // Custom Inspectors are on at the start of every Editor session
            if (!SessionState.GetBool(FirstSetupKey, false))
            {
                SessionState.SetBool(FirstSetupKey, true);
                SessionState.SetBool(PlaygroundState, true);
            }

            ApplyState();
        }

        [MenuItem(PlaygroundCustomInspectors)]
        public static void TogglePlayground()
        {
            SessionState.SetBool(PlaygroundState, !SessionState.GetBool(PlaygroundState, false));
            ApplyState();
        }

        // Adds or removes only the Playground symbols on the active build target, leaving any other symbols untouched
        private static void ApplyState()
        {
            bool playgroundOn = SessionState.GetBool(PlaygroundState, false);

            NamedBuildTarget buildTarget = NamedBuildTarget.FromBuildTargetGroup(
                BuildPipeline.GetBuildTargetGroup(EditorUserBuildSettings.activeBuildTarget));
            PlayerSettings.GetScriptingDefineSymbols(buildTarget, out string[] currentSymbols);

            string[] newSymbols = playgroundOn
                ? currentSymbols.Union(defineSymbols).ToArray()
                : currentSymbols.Except(defineSymbols).ToArray();

            // Only write when something changed, as every change triggers a recompile
            if (!new HashSet<string>(currentSymbols).SetEquals(newSymbols))
                PlayerSettings.SetScriptingDefineSymbols(buildTarget, newSymbols);

            // Also restores the checkmark, which Unity forgets on every domain reload
            EditorApplication.delayCall += () =>
                Menu.SetChecked(PlaygroundCustomInspectors, playgroundOn);
        }
    }
}
