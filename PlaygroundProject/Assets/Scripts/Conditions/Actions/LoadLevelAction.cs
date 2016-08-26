using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevelAction : MonoBehaviour, IGameplayAction
{
	public string levelName = SAME_SCENE;

	public const string SAME_SCENE = "0";
	
	public void ExecuteAction(GameObject dataObject)
	{
		if(levelName == SAME_SCENE)
		{
			//just restart the level
			SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
		}
		else
		{
			//load another scene
			SceneManager.LoadScene(levelName, LoadSceneMode.Single);
		}
	}
}