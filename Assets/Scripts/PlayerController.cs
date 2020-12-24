using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _forwardSpeed = 5f;
    [SerializeField] float _horizontalSpeed = 5f;

    public Rigidbody playerRb;

    private float firstPosition;
    private float lastPosition;
    private bool LeftWallLimit =  false;
    private bool RightWallLimit = false;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
        var forwardVector = new Vector3(0, 0, 1);
        transform.position += transform.forward * Time.deltaTime * _forwardSpeed;

        if(playerRb.position.x >= 9.8f)
        {
            RightWallLimit = true;
        }
        else if(playerRb.position.x <= -9.8f)
        {
            LeftWallLimit = true;
        }
        else
        {
            RightWallLimit = false;
            LeftWallLimit = false;
        }

        // Keyboard controls for Player

        // Mouse control for Player. It will be converted to touch controls for smart phones.
        if (Input.GetMouseButtonDown(0))
        {
            //transform.position += Vector3.right * Input.GetAxis("Mouse X") * Time.deltaTime * _forwardSpeed;
            firstPosition = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            firstPosition = 0;
            lastPosition = 0;
        }
        else if(Input.GetMouseButton(0))
        {
         
            lastPosition = Input.mousePosition.x;
            
            float x = ((lastPosition - firstPosition) / Screen.width) ;

            float difference = (lastPosition - firstPosition);

            Debug.Log("Diff:"+difference);
            Debug.Log(firstPosition + " | " + lastPosition);

            if (LeftWallLimit == false)
            {
                if (difference < -100)
                {
                    transform.position += Vector3.right * x * Time.deltaTime * _horizontalSpeed;

                }
            }

            if (RightWallLimit == false)
            {

                if (difference > 100)
                {
                    transform.position += Vector3.right * x * Time.deltaTime * _horizontalSpeed;
                }

            }


        }
 
        
    }

}
