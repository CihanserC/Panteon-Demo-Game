using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float MaxSpeed = 18;

    public Vector3 GetMovement(Vector3 direction)
    {
        return direction * MaxSpeed * Time.deltaTime;
        //transform.rotation = Quaternion.LookRotation(_direction, Vector3.up);
    }

}
