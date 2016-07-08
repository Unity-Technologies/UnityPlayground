using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
	[Header("Win condition")]
	public int scoreToWin = -1;


	[Header("References (don't touch)")]
	public Text scoreNumber;
	public Text healthNumber;
	public GameObject scorePanel, gameOverPanel, winPanel;

	private int score = 0;
	private int playerHealth;

	public void AddOnePoint()
	{
		score++;

		scoreNumber.text = score.ToString();

		if(scoreToWin != -1
			&& score >= scoreToWin)
		{
			GameWon();
		}
	}

	public void GameWon()
	{
		scorePanel.SetActive(false);
		winPanel.SetActive(true);
	}

	public void GameOver()
	{
		scorePanel.SetActive(false);
		gameOverPanel.SetActive(true);
	}

	public void SetHealth(int amount)
	{
		playerHealth = amount;
		healthNumber.text = playerHealth.ToString();
	}

	public void SubHealth(int amount)
	{
		playerHealth -= amount;

		healthNumber.text = playerHealth.ToString();

		if(playerHealth <= 0)
		{
			GameOver();
		}

	}
}
