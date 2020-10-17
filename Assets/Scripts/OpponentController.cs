using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{

    Animator animator;

    //GameObject originalGameObject = GameObject.Find("MiddleRay");
    //GameObject child = originalGameObject.transform.GetChild(3).gameObject;

    //public Collider MiddleRay;
    //public Collider LeftRay;
    //public Collider RightRay;

    public GameObject Girl;

    [Header("Sensors")]
    public float sensorLength = 10;


    [Header("REFERENCES")]
    [SerializeField] private CharacterMovement m_Movement;
    [SerializeField] private Rigidbody m_Rigidbody;


    RaycastHit hit;

    private void Awake()
    {
        m_Movement = transform.GetComponent<CharacterMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        //m_xAxis = Input.GetAxis("Horizontal");
        animator = GetComponent<Animator>();
        //animator.SetFloat("Speed", 1.0f);
    }



    void Update()
    {

        var forwardDirection = (transform.forward);
        var rightForwardDirection = (transform.forward + transform.right) / (Mathf.Sqrt(2));
        var leftForwardDirection = (transform.forward - transform.right) / (Mathf.Sqrt(2));


        // var RaycastDirection = Transform.TransformDirection(girlForward);
        var hitRight = false;
        var hitLeft = false;
        var hitForward = false;

        if (Physics.Raycast(transform.position, (transform.forward + transform.right) / (Mathf.Sqrt(2)), out hit, sensorLength))    // Right ray
        {
            hitRight = true;
            Debug.DrawLine(transform.position, transform.position + rightForwardDirection * sensorLength, Color.green);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + rightForwardDirection * sensorLength, Color.red);
        }

        if (Physics.Raycast(transform.position, (transform.forward - transform.right) / (Mathf.Sqrt(2)), out hit, sensorLength))
        {
            hitLeft = true;
            Debug.DrawLine(transform.position, transform.position + leftForwardDirection * sensorLength, Color.green);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + leftForwardDirection * sensorLength, Color.red);
        }

        if (Physics.Raycast(transform.position, transform.forward, out hit, sensorLength))
        {
            hitForward = true;
            Debug.DrawLine(transform.position, transform.position + forwardDirection * sensorLength, Color.green);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + forwardDirection * sensorLength, Color.red);
        }






        if (!hitForward)
        {
            transform.position += m_Movement.GetMovement(transform.forward);
            Debug.Log(m_Movement.GetMovement(transform.forward));
        }
        else if (!hitRight)
        {
            transform.position += m_Movement.GetMovement(rightForwardDirection);
        }
        else if (!hitLeft)
        {
            transform.position += m_Movement.GetMovement(leftForwardDirection);
        }
        else
        {
            transform.position += m_Movement.GetMovement(transform.forward);
        }



    }
}
