using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Movement;
using UnityEngine.SceneManagement;


public class PlayerCollision : MonoBehaviour
{

    public GameObject WinUI;
    public Rigidbody PlayerRigidbody;
    public GameObject Player;
    public GameObject PaintWall;

    public bool isWin = false;
    Animator m_Animator;


    void Start()
    {
        m_Animator = Player.GetComponent<Animator>();
        //bool m_Win;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("Finish") )
        {
            //WinUI.SetActive(true);
            Player.GetComponent<PController>().enabled = false;
            //Player.GetComponent<Animator>().enabled = false;
            PaintWall.SetActive(true);

            m_Animator.SetBool("Win", true);
            isWin = true;
        }

        if (col.tag.Equals("Obstacle"))
        {
            Debug.Log("Retry!");
            m_Animator.SetBool("Crash", true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Invoke("PlayAgain",3);
            Player.GetComponent<PController>().enabled = false;
            PlayerRigidbody.velocity = new Vector3(0, 0, -2); // For player's head must not be in the wall.

        }

        if (col.tag.Equals("Rotator"))
        {
            Debug.Log("Rotator hit to Player!");
            Player.GetComponent<PController>().enabled = false;
            PlayerRigidbody.AddForce(transform.forward * 100);
            Player.GetComponent<PController>().enabled = true;

        }
    }

    public void PlayAgain()
    {
        Debug.Log("Retry!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
