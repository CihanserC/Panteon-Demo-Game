using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Movement;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerCollision : MonoBehaviour
{

    public GameObject WinUI;
    public Rigidbody PlayerRigidbody;
    public GameObject Player;

    public bool isWin = false;
    Animator m_Animator;

    public RagDollEnabler ragDoll;

    void Start()
    {
        m_Animator = Player.GetComponent<Animator>();
        ragDoll = Player.GetComponent<RagDollEnabler>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("Finish") )
        {
            WinUI.SetActive(true);
            Player.GetComponent<PlayerController>().enabled = false;
            //Player.GetComponent<Animator>().enabled = false;

            m_Animator.SetBool("Win", true);
            isWin = true;
        }

        if (col.tag.Equals("Obstacle"))
        {
            Debug.Log("Retry!");
            //m_Animator.SetBool("Crash", true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Invoke("PlayAgain",3);
            Player.GetComponent<PlayerController>().enabled = false;
            ragDoll.EnableRagdoll(new Vector3(0,0,0));
            //PlayerRigidbody.velocity = new Vector3(0, 0, -2); // For player's head must not be in the wall.
            //Invoke("playerCollider", 0.5f); // it is for optimizing fall animation when player hit the obstacle.
            var vcam = CinemachineCore.Instance.GetActiveBrain(0).ActiveVirtualCamera;

            vcam.Follow = null;
            vcam.LookAt = null;

        }

        if (col.tag.Equals("Rotator"))
        {
            Debug.Log("Rotator hit to Player!");
            Player.GetComponent<PController>().enabled = false;
            PlayerRigidbody.AddForce(transform.forward * 100);
            Player.GetComponent<PController>().enabled = true;

        }

    

    }
    public void playerCollider() { // change player's capsule collider's height

        CapsuleCollider PlayerCol = transform.GetComponent<CapsuleCollider>();
        PlayerCol.height = 0.8f;

    }



    public void checkSideWalls()
    {
      
    }

    public void PlayAgain()
    {
        Debug.Log("Retry!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
