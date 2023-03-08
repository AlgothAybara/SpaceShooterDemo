using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false; //Set the boolean to false to say that game starts as playable

    public GameObject pauseMenuUI;

    //Handles the keypress for pausing the game with the esacpe key
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused) //This is set to false
            {
                Resume();
            }
            else //If pushed, then it's set to true
            {
                Pause();
            }
        }
    }

    //While game is not paused, time scale is normal and game is running
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    //Game is paused in background and menu is present
    public void Pause() 
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    //This will load a new menu that lists the player's info (speed, ship name, turn ratio, etc.)
    public void PlayerDataMenu()
    {
        Debug.Log("Loading Player Data...");
    }

    //This will quit the game and return to the main menu
    public void Quit()
    {
        Application.Quit();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}


