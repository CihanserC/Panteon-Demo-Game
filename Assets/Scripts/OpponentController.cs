using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{

    Animator animator;

    public Rigidbody girlRb;
    private float _newXPos;
    private float _startPos;

    [SerializeField] float _forwardSpeed = 5f;
    [SerializeField] float _lerpSpeed = 5f;
    [SerializeField] float _playerXvalue = 2f;

    // Start is called before the first frame update
    void Start()
    {
        girlRb = GetComponent<Rigidbody>();
        //m_xAxis = Input.GetAxis("Horizontal");
        animator = GetComponent<Animator>();
        //animator.SetFloat("Speed", 1.0f);
        _startPos = transform.position.x;
    }

    void Update()
    {

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        girlRb.MovePosition(new Vector3(Mathf.Lerp
             (transform.position.x, _newXPos, _lerpSpeed * Time.fixedDeltaTime),
             girlRb.velocity.y, transform.position.z + _forwardSpeed * Time.fixedDeltaTime));
    }
}
