using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void PlayGame()
    {
        //Move us to the scene with this name
        SceneManager.LoadScene("Game");
    }
}
