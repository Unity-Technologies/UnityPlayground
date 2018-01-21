using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExportAll
{

	[MenuItem("Playground/Export Unitypackage")]
	public static void Export () {
		string[] projectContent = AssetDatabase.GetAllAssetPaths();  
		AssetDatabase.ExportPackage(projectContent, "UnityPlayground.unitypackage", ExportPackageOptions.Recurse | ExportPackageOptions.IncludeLibraryAssets );  
		
		Debug.Log("Project Exported");
	}
}
