using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevelAction : MonoBehaviour
{
	public string levelName;
	
	public void LoadNewLevel()
	{
		SceneManager.LoadScene(levelName, LoadSceneMode.Single);
	}
}