using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlController : MonoBehaviour
{
    Animator animator;

    [Header("Rays")]
    public float RayLength = 6f;
    public Vector3 frontRayPosition = new Vector3(0f, 0.2f, 0.5f);
    public float frontSideRayPosition = 0.2f;
    public float frontRayAngle = 30f;

    [Header("REFERENCES")]
    [SerializeField] private CharacterMovement m_Movement;
    [SerializeField] private Rigidbody m_Rigidbody;


    private void Awake()
    {
        m_Movement = transform.GetComponent<CharacterMovement>();
    }

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        //animator.SetFloat("Speed", 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        CheckPath();

        
    }

    void CheckPath()
    {
        RaycastHit hit;
        Vector3 rayStartPos = transform.position;
        rayStartPos += transform.forward * frontRayPosition.z;
        rayStartPos += transform.up * frontRayPosition.y;
        float avoidMultiplier = 0;

        var hitFrontRight = false;
        var hitFrontLeft = false;
        var hitRightAngle = false;
        var hitLeftAngle = false;



        var forwardDirection = (transform.forward);
        var rightForwardDirection = (transform.forward + transform.right) / (Mathf.Sqrt(2));
        var leftForwardDirection = (transform.forward - transform.right) / (Mathf.Sqrt(2));

        //front right 
        rayStartPos += transform.right * frontSideRayPosition;
        if (Physics.Raycast(rayStartPos, transform.forward, out hit, RayLength))
        {
            hitFrontRight = true;
            //Debug.DrawLine(rayStartPos, hit.point);
            avoidMultiplier -= 1f;
            
        }

        //front right angle 
        else if (Physics.Raycast(rayStartPos, Quaternion.AngleAxis(frontRayAngle, transform.up) * transform.forward, out hit, RayLength))
        {
            hitRightAngle = true;
            //Debug.DrawLine(rayStartPos, hit.point);
            avoidMultiplier -= 0.5f;
            
        }

        //front left 
        rayStartPos -= transform.right * frontSideRayPosition * 2;
        if (Physics.Raycast(rayStartPos, transform.forward, out hit, RayLength))
        {
            hitFrontLeft = true;
            //Debug.DrawLine(rayStartPos, hit.point);
            avoidMultiplier += 1f;
            
        }

        //front left angle 
        else if (Physics.Raycast(rayStartPos, Quaternion.AngleAxis(-frontRayAngle, transform.up) * transform.forward, out hit, RayLength))
        {
            hitLeftAngle = true;
            //Debug.DrawLine(rayStartPos, hit.point);
            avoidMultiplier += 0.5f;
            
        }

        if (hitFrontRight == true || hitFrontLeft == true) // If on the front side has obstacle;
        {

            if (hitRightAngle == false && hitLeftAngle== true) // If right side is empty
            {
                transform.position += m_Movement.GetMovement(rightForwardDirection);

            }
            else if (hitRightAngle == true && hitLeftAngle == false) // If left side is empty
            {
                transform.position += m_Movement.GetMovement(leftForwardDirection);

            }
            else if(hitRightAngle== false && hitLeftAngle==false) // Both LeftAngle and RightAngle is empty
            {
                transform.position += m_Movement.GetMovement(leftForwardDirection);

            }
            if (hitFrontRight==true && hitFrontLeft== false) // Slightly move to left 
            {
                transform.position += m_Movement.GetMovement(leftForwardDirection);

            }
            else if (hitFrontRight == false && hitFrontLeft == true) // Slightly move to right 
            {
                transform.position += m_Movement.GetMovement(rightForwardDirection);

            }
        }
        else
        {
            transform.position += m_Movement.GetMovement(transform.forward);

        }

  

    }
}
