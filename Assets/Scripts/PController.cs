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


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //m_xAxis = Input.GetAxis("Horizontal");
        animator = GetComponent<Animator>();
        //animator.SetFloat("Speed", 1.0f);
        _startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        var forwardVector = new Vector3(0, 0, 1);
        playerRb.velocity = forwardVector.normalized * _forwardSpeed;

        if (Input.GetMouseButton(0) )
        {
            _newXPos = Mathf.Clamp(transform.position.x + Input.GetAxis("Mouse X") *
            _playerXvalue, _startPos + _clampvalues.x, _startPos + _clampvalues.y);

        }
        
    }

    void FixedUpdate()
    {
        playerRb.MovePosition(new Vector3(Mathf.Lerp
        (transform.position.x, _newXPos, _lerpSpeed * Time.fixedDeltaTime),
        playerRb.velocity.y, transform.position.z + _forwardSpeed * Time.fixedDeltaTime));
    }
}
