using UnityEngine;
using TMPro;

public class SetWinnerDescription : MonoBehaviour
{
    public TextMeshProUGUI WinnerDescription;

    //Functions that is called when this script
    //is being loaded.
    //(For example if this scene is getting
    //loaded)
    //https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-sceneLoaded.html
    void Awake()
    {
        SetGameOverWinner();
    }

    private void SetGameOverWinner()
    {
        //Gets the name of the player that
        //has won
        string winnerName = PlayerPrefs.GetString("PlayerWinner");
        
        //Updates the game over scene description
        WinnerDescription.text = $"{winnerName} has won";
    }
}
