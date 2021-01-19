using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Rocket : MonoBehaviour
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

    //rocket config
    [SerializeField] float fuel = 500f;
    [SerializeField] Text text;
    [SerializeField] int health = 2;

    enum State {Alive, Dying, Transcending }
    State state = State.Alive;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        GameFlow();
    }

    private void GameFlow()
    {
        if (state == State.Alive)
        {
            text.text = fuel.ToString();
            Thrust();
            Rotate();
        }
       
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive) { return; }
        
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                {
                    Debug.Log("Ok");
                    break;
                }
            case "Finished":
                {
                   
                   Invoke("LoadNextScnene", 1f);
                   break;
                }
            default:
                {
                    Debug.Log("Dead");

                    if (health <= 0)
                    {
                        state = State.Dying;
                        Debug.Log("Dead");
                        Invoke("LoadFirstLevel", 2f);
                    }
                    else
                    {
                        health -= 1;
                    }
                    break;
                }
        }
    }

    private void LoadFirstLevel()
    {
       
            SceneManager.LoadScene(0);
        
    }

    private void LoadNextScnene()
    {
        if (SceneManager.sceneCount == SceneManager.GetActiveScene().buildIndex)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
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
            fuel -= 0.2f;
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