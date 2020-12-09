using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEditorInternal;

public class GameManager : MonoBehaviour
{

    GameObject finishline;
    private bool isPaused = false;
    public GameObject PauseMenu;

    //public GameObject WinMenu;

    [System.Obsolete]
    public void PlayAgain()
    {
        //Debug.Log("Retry!");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Application.LoadLevel(Application.loadedLevel);

    }

    public void Play() // For play button
    {
        //Debug.Log("Play!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GotoMenu()
    {
        Time.timeScale = 1;
        Debug.Log("Go to main menu!");
        SceneManager.LoadScene("Menu");

    }

    [System.Obsolete]
    public void QuitGame()
    {
        Debug.Log("You quit!");
        //FindObjectOfType<MainMenu>().Quitgame();
        Application.Quit();
        Application.LoadLevel(Application.loadedLevel);


    }

    public void PauseGame()
    {
        isPaused = !isPaused;

        if (isPaused == true)
        {
            
            PauseMenu.SetActive(true);
            Time.timeScale = 0; // Freeze the game
            //isPaused = false;
        }
        else if(isPaused == false)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1; // Continue to the game
            //isPaused = true;
        }
    }


    public void NextLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
