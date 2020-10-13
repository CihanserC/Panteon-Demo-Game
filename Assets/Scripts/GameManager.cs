using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    GameObject finishline;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgain()
    {
        Debug.Log("Retry!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Play() // For play button
    {
        Debug.Log("Play!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );
    }

    public void GotoMenu()
    {
        Debug.Log("Go to main menu!");
        SceneManager.LoadScene("Menu");

    }

    public void QuitGame()
    {
        Debug.Log("You quit!");
        //FindObjectOfType<MainMenu>().Quitgame();
        Application.Quit();

    }
}
