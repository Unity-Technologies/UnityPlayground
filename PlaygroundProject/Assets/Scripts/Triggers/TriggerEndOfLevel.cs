using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TriggerEndOfLevel : TriggerArea
{
	public string levelName;

	public string filterTag = "Player";
	
	// This function will be called when something enters the trigger
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if(otherCollider.CompareTag(filterTag))
		{
			SceneManager.LoadScene(levelName, LoadSceneMode.Single);
		}
	}
}