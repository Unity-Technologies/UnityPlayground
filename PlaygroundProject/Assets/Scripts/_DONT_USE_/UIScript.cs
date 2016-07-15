using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
	[Header("Configuration")]
	public Players numberOfPlayers = Players.OnePlayer;

	public GameType gameType = GameType.Score;

	// If the scoreToWin is -1, the game becomes endless (no win conditions, but you could do game over)
	public int scoreToWin = -1;


	[Header("References (don't touch)")]
	//Right is used for the score in P1 games
	public Text[] numberLabels = new Text[2];
	public Text rightLabel, leftLabel;
	public GameObject statsPanel, gameOverPanel, winPanel;


	// Internal variables to keep track of score and players' health
	private int[] scores = new int[2];
	private int[] playersHealth = new int[2];


	private void Start()
	{
		if(numberOfPlayers == Players.OnePlayer)
		{
			// No setup needed
		}
		else
		{
			if(gameType == GameType.Score)
			{
				// Show the 2-player score interface
				rightLabel.text = leftLabel.text = "Score";

				// Show the score as 0 for both players
				numberLabels[0].text = numberLabels[1].text = "0";
				scores[0] = scores[1] = 0;
			}
			else
			{
				// Show the 2-player life interface
				rightLabel.text = leftLabel.text = "Life";

				// Life will be provided by the PlayerHealth components
			}
		}
	}


	public void AddOnePoint(int playerNumber)
	{
		scores[playerNumber]++;

		numberLabels[playerNumber].text = scores[playerNumber].ToString();

		if(scoreToWin != -1
			&& scores[playerNumber] >= scoreToWin)
		{
			GameWon(playerNumber);
		}
	}



	public void GameWon(int playerNumber)
	{
		statsPanel.SetActive(false);
		winPanel.SetActive(true);
	}



	public void GameOver(int playerNumber)
	{
		statsPanel.SetActive(false);
		gameOverPanel.SetActive(true);
	}



	public void SetHealth(int amount, int playerNumber)
	{
		playersHealth[playerNumber] = amount;
		numberLabels[playerNumber].text = playersHealth.ToString();
	}



	public void SubHealth(int change, int playerNumber)
	{
		SetHealth(playersHealth[playerNumber] - change, playerNumber);

		if(playersHealth[playerNumber] <= 0)
		{
			GameOver(playerNumber);
		}

	}



	public enum Players
	{
		OnePlayer,
		TwoPlayers
	}

	public enum GameType
	{
		Score,
		Life
	}
}
