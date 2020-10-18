using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnim : MonoBehaviour
{
    Animator m_CameraAnimator;
    public GameObject Camera;
    public PlayerCollision playerCol;

    // Start is called before the first frame update
    void Start()
    {
        m_CameraAnimator = Camera.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCol.isWin == true)
        {
            m_CameraAnimator.SetBool("isWin", true);
        }
    }
}
