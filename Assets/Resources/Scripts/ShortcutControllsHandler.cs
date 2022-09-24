using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShortcutControllsHandler : MonoBehaviour
{
    private bool isAIOn = false;

    private void Start()
    {
        //In the beggining the AI should always be disabled
        PlayerPrefs.SetString("isAIOn", "false");
    }

    //Code to be executed once this scene is loaded
    //again. (After game over for example)
    private void Awake()
    {
        //The AI code should only be acessible in
        //the game scene
        if (SceneManager.GetActiveScene().name == "Game")
        {
            //On the scene loaded it unity sets everything
            //to its defaults, so racketPlayer2 have AI
            // script disabled per default, event it was
            //on, so we use the following code to update
            //it
            bool isAIOn = bool.Parse(PlayerPrefs.GetString("isAIOn"));

            GameObject racketPlayer2 = GameObject.Find("RacketPlayer2");

            if (isAIOn)
            {
                racketPlayer2.GetComponent<RacketPlayer2>().enabled = false;
                racketPlayer2.GetComponent<AIController>().enabled = true;
            }
            else
            {
                racketPlayer2.GetComponent<RacketPlayer2>().enabled = true;
                racketPlayer2.GetComponent<AIController>().enabled = false;
            }
        }
    }

    private void Update()
    {
        //Closes the game
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        //Toggle between fullscreen and window mode
        else if (Input.GetKeyDown(KeyCode.F11))
        {
            //Gets the actual state of the fullscreen
            FullScreenMode screenMode = Screen.fullScreenMode;

            //If it is not at fullscreen, then it sets
            //it to be
            if(screenMode == FullScreenMode.Windowed)
            {
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            }
            //If it is then, it sets to be normal window
            else
            {
                Screen.fullScreenMode = FullScreenMode.Windowed;
            }
        }
        //Toggled the AI controller for the player 2
        //on and off. (In case it does not have
        //anyone to play in the same keyboard)
        //This could should only be acessible in the
        //game scene
        else if ((Input.GetKeyDown(KeyCode.F1)) && (SceneManager.GetActiveScene().name == "Game"))
        {
            //Toggles the value indicating if the AI
            //should be one.
            //(Use PlayerPref to save value after
            //game over)
            bool actualValue = bool.Parse(PlayerPrefs.GetString("isAIOn"));
            bool isAIOn = !actualValue;

            GameObject racketPlayer2 = GameObject.Find("RacketPlayer2");

            if (isAIOn)
            {
                racketPlayer2.GetComponent<RacketPlayer2>().enabled = false;
                racketPlayer2.GetComponent<AIController>().enabled = true;
                PlayerPrefs.SetString("isAIOn", "true");
            }
            else
            {
                racketPlayer2.GetComponent<RacketPlayer2>().enabled = true;
                racketPlayer2.GetComponent<AIController>().enabled = false;
                PlayerPrefs.SetString("isAIOn", "false");
            }
        }
    }
}
