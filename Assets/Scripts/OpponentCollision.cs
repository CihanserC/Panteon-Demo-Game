using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCollision : MonoBehaviour
{

    Animator m_Animator;
    public GameObject Opponent;

    [SerializeField] private CharacterMovement m_Movement;
    [SerializeField] private Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
        //animator.SetFloat("Speed", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        m_Movement = transform.GetComponent<CharacterMovement>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("Finish"))
        {
            Opponent.GetComponent<PController>().enabled = false;
            Opponent.SetActive(true);
            m_Animator.SetBool("Win", true);
        }

        if (col.tag.Equals("Obstacle"))
        {
            m_Animator.SetBool("isCrash", true);
            Opponent.GetComponent<OpponentController>().enabled = false;
            m_Rigidbody.velocity = new Vector3(0, 0, -2);   // For opponents's head must not be in the wall.
            transform.position += m_Movement.GetMovement(new Vector3(0,0,0));


        }

        if (col.tag.Equals("Rotator"))
        {
            m_Rigidbody.AddForce(transform.forward * 10);
        }
    }


}
