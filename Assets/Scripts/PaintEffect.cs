using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintEffect : MonoBehaviour
{
    public GameObject maskPrefab;
    private bool isPressed = false; 

    void Start()
    {
        
    }

    void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 0.4f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if(isPressed == true)
        {
            GameObject MaskSprite = Instantiate(maskPrefab , mousePos, Quaternion.identity);
            MaskSprite.transform.parent = gameObject.transform;
        }
        else
        {

        }

        if(Input.GetMouseButtonDown(0))
        {
            Invoke("reveal",10);
            isPressed = true;
        }else if (Input.GetMouseButtonUp(0))
        {
            isPressed = false;

        }
    }

    void ShowWinUI()
    {
        
    }

    void reveal()
    {
        Destroy(this.gameObject);
    }
}
