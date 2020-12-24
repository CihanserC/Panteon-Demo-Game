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

    private void Start()
    {
        Application.targetFrameRate = 60 ;  
    }

    public void QuitGame()
    {
        Debug.Log("You quit!");
        //FindObjectOfType<MainMenu>().Quitgame();
        Application.Quit();
    }
    
    public void PlayAgain()
    {
        //Debug.Log("Retry!");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
