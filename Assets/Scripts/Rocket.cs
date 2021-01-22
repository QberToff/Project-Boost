﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Rocket : MonoBehaviour
{
    //cashed references
    Rigidbody rb;
    [SerializeField] SceneLoader sceneLoader;


    //movement config
    [Header("Movement Config")]
    [SerializeField] float thrust = 1000f;
    [SerializeField] float rcsThrust = 250f;
    bool thrustIsPressed;
    bool leftIsPressed;
    bool rightIsPressed;

    //rocket config
    [Header("Rocket Config")]
    [SerializeField] int health = 2;

    //fuel config
    [Header("Fuel config")]
    [SerializeField] float fuel = 500f;
    [SerializeField] float consumption = 0.2f;
    bool fuelTankEmpy = false;
    float startFuel;

    //audio config
    [Header("Audio Config")]
    [SerializeField] AudioClip thrustSFX;
    [SerializeField] AudioClip collisionSFX;
    [SerializeField] AudioClip winSFX;
    [SerializeField] AudioClip deathSFX;
    AudioSource audioSource;

    //Particle config
    [Header("Particle config")]
    [SerializeField] ParticleSystem thrustVFX; 

    enum State {Alive, Dying, Transcending }
    State state = State.Alive;

    public int GetHealth()
    {
        return health;
    }
    public float GetFuel()
    {
        return fuel;
    }
    public float GetStartFuel()
    {
        return startFuel;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        startFuel = fuel;

    }

    // Update is called once per frame
    void Update()
    {
        
        GameFlow();
    }

    private void GameFlow()//method for checking is player Alive
    {
        if (state == State.Alive)
        {
           
            RespondToThrust();
            RespondToRotate();
        }
       
       
    }


 
    private void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(collisionSFX);
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
                    Win();
                    break;
                }
            default:
                {

                    health -= 1;
                      if (health <= 0)
                      {
                          state = State.Dying;
                          Die();

                      }          
                    break;
                }
        }
    }

    

  

    public void ThrustPointerDown()
    {
        thrustIsPressed = true;
    }//thrust button down

    public void ThrustPointerUp()
    {
        thrustIsPressed = false;
    }//thrust button up

    public void LeftPointerDown()
    {
        leftIsPressed = true;
    }//left button down

    public void LeftPointerUp()
    {
        leftIsPressed = false;
    }//left button up

    public void RightPointerDown()
    {
        rightIsPressed = true;
    }//right button down

    public void RightPointerUp()
    {
        rightIsPressed = false;
    }//right button up

    private void RespondToThrust()//checking input for thrust
    {
        if (fuel > 0)
        {
            if (thrustIsPressed || Input.GetKey(KeyCode.Space))
            {
                Thrust();
            }
            else
            {
                audioSource.Stop();
                thrustVFX.Stop();
            }
        }
        
    }

    private void RespondToRotate()//checking input for rotate
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

    private void Thrust()/*by calling this method player could fly rocket 
                          * in upwards direction, also thrustSFX playing*/
    {
        
        FuelCount();
        rb.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(thrustSFX);
        }
        if (!thrustVFX.isPlaying)
        {
            thrustVFX.Play();
        }
    }

    private void FuelCount()
    {
        fuel -= consumption;
    }
   

    private void Die()//method which load first level, when Player lost
    {
        
        Debug.Log("Dead");
        thrustVFX.Stop();
        audioSource.Stop();
        audioSource.PlayOneShot(deathSFX);
        StartCoroutine(FirstLevel());
        //Invoke("LoadFirstLevel", 2f);
    }

    private void Win()
    {
        Debug.Log("Win");
        state = State.Transcending;
        audioSource.Stop();
        audioSource.PlayOneShot(winSFX);
        StartCoroutine(NextLevel());
        //Invoke("LoadNextScnene", 4f);
    }



   IEnumerator FirstLevel()
    {
        yield return new WaitForSeconds(4f);
        sceneLoader.LoadFirstLevel();

    }
    
    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(4f);
        sceneLoader.LoadNextScnene();
    }

}