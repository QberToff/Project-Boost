using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float smoothSpeed = 10f;
    [SerializeField] Vector3 offset;

    
    private void FixedUpdate()
    {
        Vector3 nextPosition = target.transform.position + offset;
        Vector3 smoothedPosotion = Vector3.Lerp(transform.position, nextPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosotion;
    }
}

