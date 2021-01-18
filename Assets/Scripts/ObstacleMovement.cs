using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 targetPosition;
    [SerializeField] float speed = 10f;
    Vector3 currentPosition;
     void Start()
    {
        currentPosition = transform.position;
    }

     void Update()
    {
        ObstacleMove(transform.position, targetPosition);
        if (transform.position == targetPosition)
        {
            targetPosition = currentPosition;
            currentPosition = transform.position;
        }
    }

    private void ObstacleMove(Vector3 a, Vector3 b)
    {
        
        transform.position = Vector3.MoveTowards(a, b, speed * Time.deltaTime);
        /*if(transform.position == targetPosition)
        {
            Debug.Log("reached");
            //transform.position = Vector3.MoveTowards(transform.position, currentPosition, speed * Time.deltaTime);
        }*/
    }
}
