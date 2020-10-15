using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController : MonoBehaviour
{
    Animator animator;

    private float m_xAxis;
    public float currentSpeed;

    [SerializeField] float _forwardSpeed = 5f;
    [SerializeField] float _lerpSpeed= 5f;
    [SerializeField] float _playerXvalue = 2f;

    [SerializeField] Vector2 _clampvalues = new Vector2(-2, 2) ;

    public Rigidbody playerRb;
    private float _newXPos;
    private float _startPos;

    public float distance = 1.0f;


    // Start is called before the first frame update
    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        //m_xAxis = Input.GetAxis("Horizontal");
        animator = GetComponent<Animator>();
        animator.SetFloat("Speed", 1.0f);
        _startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Horizontal"))
        //{
        //    //_newXPos = Mathf.Clamp(transform.position.x + Input.GetAxisRaw("Horizontal") * 
        //    //    _playerXvalue , _startPos + _clampvalues.x , _startPos + _clampvalues.y);
        //}

        if (Input.GetMouseButton(0) )
        {
            //_newXPos= transform.position.x + Input.GetAxis("Mouse X") * Time.deltaTime ;

            _newXPos = Mathf.Clamp(transform.position.x + Input.GetAxis("Mouse X") *
                _playerXvalue , _startPos + _clampvalues.x , _startPos + _clampvalues.y);

             //_newXPos = transform.position.x + Input.GetAxis("Mouse X");

            //Vector3 mousePosition = Input.mousePosition;
            //mousePosition.x = distance;
            //playerRb.transform.position = Camera.main.ScreenToWorldPoint(mousePosition).x;
        }

        //Debug.Log("Mouse X:"+Input.GetAxis("Mouse X"));
        //Debug.Log("_newXPos" + _newXPos);

        
    }

    private void FixedUpdate()
    {

        //Vector3 playerPos = new Vector3(Mathf.Lerp(transform.position.x, _newXPos, _lerpSpeed * Time.fixedDeltaTime),
        //     playerRb.velocity.y, transform.position.z + _forwardSpeed * Time.fixedDeltaTime);

       
        playerRb.MovePosition(new Vector3(Mathf.Lerp
             (transform.position.x, _newXPos, _lerpSpeed * Time.fixedDeltaTime),
             playerRb.velocity.y, transform.position.z + _forwardSpeed * Time.fixedDeltaTime));

        //playerRb.MovePosition(new Vector3(0, 0, transform.position.z + _forwardSpeed * Time.fixedDeltaTime));
        //playerRb.MovePosition(transform.position + Time.deltaTime * currentSpeed *

        //transform.TransformDirection(0f, 0f, m_zAxis)); // m_zAxis gives the constant velocity.
        //playerRb.MoveRotation(Quaternion.Euler(playerRb.rotation.eulerAngles + new Vector3(0f, rotationRate * Input.GetAxis("Mouse X"), 0f)));

    }
}
