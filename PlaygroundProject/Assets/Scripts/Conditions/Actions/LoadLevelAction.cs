using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevelAction : MonoBehaviour, IGameplayAction
{
	public string levelName;
	
	public void ExecuteAction()
	{
		SceneManager.LoadScene(levelName, LoadSceneMode.Single);
	}
}