using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void Play()
   {
    //Menu will be loaded as index 0 for Scene Builder.
    //When 'Play' is pressed, it will be loaded next into Scene Builder as index 1
    Debug.Log("Game Loaded and Playing");
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

    public void Quit()
    {
        //When 'Quit' is clicked, application will be closed.
        Debug.Log("Quit");
        Application.Quit();
    }
}
