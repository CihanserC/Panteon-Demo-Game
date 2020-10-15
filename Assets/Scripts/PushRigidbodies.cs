using UnityEngine;
using System.Collections;

public class PushRigidbodies : MonoBehaviour
{
    Rigidbody body;
    Vector3 pushDir;
    float power = 2.0f;
    //float minPower = 0.5f;
    //float maxPower = 3.0f;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.rigidbody)
            body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
            return;

        if (hit.moveDirection.y < -0.3F)
            return;

        if (body != null)
        {
            pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            body.velocity = pushDir * power;
        }
    }
}
