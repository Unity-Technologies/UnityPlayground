using UnityEditor;
using UnityEngine;

namespace Playground.Editor
{
	public class MenuItemFunctions
	{
		[MenuItem("Playground/Turn Playground Off")]
		public static void TurnOff ()
		{
			PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, "");
		
			Debug.Log("Turned Playground off");
		}

		[MenuItem("Playground/Turn Playground On")]
		public static void TurnOn ()
		{
			PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, "GAMEOBJECT_HEADER; DEFAULT_INSPECTORS; CUSTOM_INSPECTORS");
		
			Debug.Log("Turned Playground on");
		}
	}
}
