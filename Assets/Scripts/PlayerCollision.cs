using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Movement;
using UnityEngine.SceneManagement;


public class PlayerCollision : MonoBehaviour
{

    Animator animator;
    public GameObject WinUI;
    public Rigidbody PlayerRigidbody;
    public GameObject Player;
    public GameObject PaintWall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("Finish") )
        {
                    WinUI.SetActive(true);
            Player.GetComponent<PlayerController>().enabled = false;
            Player.GetComponent<Animator>().enabled = false;
            PaintWall.SetActive(true);
        }

        else if (col.tag.Equals("Obstacle"))
        {
            Debug.Log("Retry!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
