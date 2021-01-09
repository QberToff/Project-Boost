using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    [SerializeField] float thrust = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();   
    }

    void ProcessInput()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Thrusting");
            rigidBody.AddRelativeForce(Vector3.up * thrust);
            
        }
        if(Input.GetKey(KeyCode.A))
        {
            Debug.Log("Left pressed");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Right pressed");
        }
    }

}
