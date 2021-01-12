using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    [SerializeField] float thrust = 1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        
        }

        else
        {
            audioSource.Stop();
        }



        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Left pressed");
            transform.Rotate(Vector3.back);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Right pressed");
            transform.Rotate(Vector3.forward);
        }
    }

}
