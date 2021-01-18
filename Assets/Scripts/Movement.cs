using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    //cashed references
    Rigidbody rb;
    AudioSource audioSource;

    //movement config
    [SerializeField] float thrust = 1000f;
    [SerializeField] float rcsThrust = 250f;
    bool thrustIsPressed;
    bool leftIsPressed;
    bool rightIsPressed;

    //fuel config
    [SerializeField] float fuel = 500f;
    [SerializeField] Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = fuel.ToString();
        Thrust();
        Rotate();
    }

    public void ThrustPointerDown()
    {
        thrustIsPressed = true;
    }

    public void ThrustPointerUp()
    {
        thrustIsPressed = false;
    }

    public void LeftPointerDown()
    {
        leftIsPressed = true;
    }

    public void LeftPointerUp()
    {
        leftIsPressed = false;
    }

    public void RightPointerDown()
    {
        rightIsPressed = true;
    }

    public void RightPointerUp()
    {
        rightIsPressed = false;
    }

    private void Thrust()
    {
        if (thrustIsPressed || Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("thrust");
            rb.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
            fuel -= 1;
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

    private void Rotate()
    {
        rb.freezeRotation = true;
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (leftIsPressed || Input.GetKey(KeyCode.A))
        {

            transform.Rotate(Vector3.back * rotationThisFrame);
        }
        else if (rightIsPressed || Input.GetKey(KeyCode.D))
        {

            transform.Rotate(Vector3.forward * rotationThisFrame);
        }

        rb.freezeRotation = false;
    }
}

