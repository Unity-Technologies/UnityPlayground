using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TriggerEndOfLevel : TriggerArea
{
	[Space(20)]
	public string levelName;

	void Start()
	{
		playerOnly = true;
	}
	
	// This function will be called when something enters the trigger
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if(CheckIfPlayerOnly(otherCollider))
		{
			SceneManager.LoadScene(levelName, LoadSceneMode.Single);
		}
	}
}