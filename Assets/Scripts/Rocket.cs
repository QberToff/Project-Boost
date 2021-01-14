using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    [SerializeField] float thrust = 1;
    [SerializeField] float rcsThrust = 100f;
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
        Thrust();
        Rotate();   
    }


    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
            {
            case "Friendly":
                {
                    Debug.Log("Ok");
                    break;
                }
            default:
                {
                    Debug.Log("Dead");
                    break;
                }
            }
    }

    void Rotate()
    {
        rigidBody.freezeRotation = true;
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
          
           
            transform.Rotate(Vector3.back * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }

        rigidBody.freezeRotation = false;
    }

     public void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            rigidBody.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

        }

        else
        {
            audioSource.Stop();
        }
    }
}
