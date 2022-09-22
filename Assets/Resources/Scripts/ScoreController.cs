using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;

    public GameObject scoreTextPlayer1;
    public GameObject scoreTextPlayer2;

    public int goalToWin;

    //Constantly check if one of the
    //players has won
    void Update()
    {
        //Verifies if one of the players has won
        if (this.scorePlayer1 >= this.goalToWin || this.scorePlayer2 >= this.goalToWin)
        {
            string winner = "";

            if (this.scorePlayer1 >= this.goalToWin)
                winner = "Player 1 ";
            else
                winner = "Player 2 ";

            //Sets which player have won to appear
            //on the game over screen
            PlayerPrefs.SetString("PlayerWinner", winner);
            
            SceneManager.LoadScene("GameOver");
        }
    }

    //Update the UI
    private void FixedUpdate()
    {
        //Gets the text element of this Game
        //object
        TextMeshProUGUI uiScorePlayer1 = this.scoreTextPlayer1.GetComponent<TextMeshProUGUI>();
        //Gets the score and update the element with it
        uiScorePlayer1.text = this.scorePlayer1.ToString();

        TextMeshProUGUI uiScorePlayer2 = this.scoreTextPlayer2.GetComponent<TextMeshProUGUI>();
        uiScorePlayer2.text = this.scorePlayer2.ToString();
    }

    public void GoalPlayer1()
    {
        this.scorePlayer1++;
    }

    public void GoalPlayer2()
    {
        this.scorePlayer2++;
    }
}
