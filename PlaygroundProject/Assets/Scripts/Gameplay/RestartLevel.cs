using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartLevel : MonoBehaviour
{
	[Header("Input key")]

	// the key used to reload the level
	public KeyCode key = KeyCode.R;

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyUp(key))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
