using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragObject : MonoBehaviour
{
    private Touch touch;
    private Vector2 mouse;

    private float speedModifier;

    void Start()
    {
        speedModifier = 0.001f;
    }


    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedModifier,
                transform.position.y,
                transform.position.z + touch.deltaPosition.y * speedModifier);
            }
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    mouse = Input.mousePosition;

        //    transform.position = new Vector3(transform.position.x + mouse.x * speedModifier,
        //    transform.position.y,
        //    transform.position.z + mouse.y * speedModifier);

        //}
    }
}


