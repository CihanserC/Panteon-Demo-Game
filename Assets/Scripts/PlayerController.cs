using System.Collections;
//using UnityEditor.UIElements;
using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        Animator animator;

        public float rotationRate = 10;
        #region PUBLIC FIELDS
        [Header("Walk / Run Setting")] public float walkSpeed;
        public float runSpeed;
        public ForceMode appliedForceMode;



        [Header("Current Player Speed")] public float currentSpeed;
        [Header("Ground LayerMask name")] public string groundLayerMask;
        [Header("Raycast Distance")] public float raycastDistance;

        #endregion

        #region PRIVATE FIELDS

        private float m_xAxis;
        private float m_zAxis;
        private Rigidbody m_rb;
        private RaycastHit m_hit;
        private Vector3 m_groundLocation;
        private bool m_leftShiftPressed;
        private int m_groundLayerMask;
        private float m_distanceFromPlayerToGround;
        private bool m_playerIsGrounded;
        #endregion



        #region MONODEVELOP ROUTINES

        private void Start()
        {
            #region initializing components

            m_rb = GetComponent<Rigidbody>();

            #endregion

            #region get layer mask [env ground layer]

            m_groundLayerMask = LayerMask.GetMask(groundLayerMask);

            #endregion

            animator = GetComponent<Animator>();
            Debug.Log(animator);
        }

        private void Update()
        {
            #region controller Input [horizontal | vertical ] movement

            m_xAxis = Input.GetAxis("Horizontal");
            //m_xAxis = 10;
            //m_zAxis = Input.GetAxis("Vertical");
            m_zAxis = 1;

            #endregion

            #region adjust player move speed [walk | run]

            currentSpeed = m_leftShiftPressed ? runSpeed : walkSpeed;

            #endregion

            
           animator.SetFloat("Speed", 1.0f);
          

            #endregion

            #region Shift To Change Speed

            m_leftShiftPressed = Input.GetKey(KeyCode.LeftShift);

            #endregion

            #region compute player distance from ground

            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * raycastDistance, Color.blue);
            //added layermask for those dealing with complex ground objects.
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out m_hit,
                raycastDistance, m_groundLayerMask))
            {
                m_groundLocation = m_hit.point;
                m_distanceFromPlayerToGround = transform.position.y - m_groundLocation.y;
            }

            #endregion
        }

       

        private void FixedUpdate()
        {
            #region move player

            m_rb.MovePosition(transform.position + Time.deltaTime * currentSpeed *
                transform.TransformDirection(0f, 0f, m_zAxis)); // m_zAxis gives the constant velocity.

            m_rb.MoveRotation( Quaternion.Euler(m_rb.rotation.eulerAngles + new Vector3(0f, rotationRate * Input.GetAxis("Mouse X"), 0f)));

            #endregion


            m_playerIsGrounded = m_distanceFromPlayerToGround <= 1f;

        }

      
    }
}