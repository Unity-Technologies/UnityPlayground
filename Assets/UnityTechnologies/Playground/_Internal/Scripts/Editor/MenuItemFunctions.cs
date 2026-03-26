using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuItemFunctions
{
	/*
	[MenuItem("Playground/Export Unitypackage")]
	public static void Export () {
		string[] projectContent = AssetDatabase.GetAllAssetPaths();  
		AssetDatabase.ExportPackage(projectContent, "UnityPlayground.unitypackage", ExportPackageOptions.Recurse | ExportPackageOptions.IncludeLibraryAssets );  
		
		Debug.Log("Project exported");
	}
	*/

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
