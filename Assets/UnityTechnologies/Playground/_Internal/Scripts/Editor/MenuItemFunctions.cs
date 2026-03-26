using UnityEditor;
using UnityEditor.Build;
using UnityEngine;

namespace Playground.Editor
{
	public class MenuItemFunctions
	{
		private static readonly string[] defineSymbols = {
			"GAMEOBJECT_HEADER",
			"DEFAULT_INSPECTORS",
			"CUSTOM_INSPECTORS",
		};
		
		[MenuItem("Playground/Turn Playground Off")]
		public static void TurnOff ()
		{
			PlayerSettings.SetScriptingDefineSymbols(NamedBuildTarget.Standalone, "");
			Debug.Log("Turned Playground off");
		}

		[MenuItem("Playground/Turn Playground On")]
		public static void TurnOn ()
		{
			PlayerSettings.SetScriptingDefineSymbols(NamedBuildTarget.Standalone, defineSymbols);
			Debug.Log("Turned Playground on");
		}
	}
}
