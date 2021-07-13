using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5.0f;


    void FixedUpdate()
    {
        Vector3 newPos = new Vector3(target.position.x + 2f, target.position.y + 1.5f, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * 0.001f));
    }
}
