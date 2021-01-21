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


    //movement config
    [Header("Movement Config")]
    [SerializeField] float thrust = 1000f;
    [SerializeField] float rcsThrust = 250f;
    bool thrustIsPressed;
    bool leftIsPressed;
    bool rightIsPressed;

    //rocket config
    [Header("Rocket Config")]
    [SerializeField] float consumption = 0.2f;
    [SerializeField] FuelbarController fuelBar;
    [SerializeField] int health = 2;

    //audio config
    [Header("Audio Config")]
    [SerializeField] AudioClip thrustSFX;
    [SerializeField] AudioClip collisionSFX;
    [SerializeField] AudioClip winSFX;
    [SerializeField] AudioClip deathSFX;
    AudioSource audioSource;

    //Particle config
    //[Header("Particle config")]
    //[SerializeField] ParticleSystem thrustVFX; 

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
        FuelCheck();
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


    private void FuelCheck() // checking does player have fuel
    {
        if (fuelBar.GetFuel() <= 0)
        {
            Debug.Log("fuel end");
            state = State.Dying;
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

    private void Win()
    {
        Debug.Log("Win");
        state = State.Transcending;
        audioSource.Stop();
        audioSource.PlayOneShot(winSFX);
        Invoke("LoadNextScnene", 4f);
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

    private void RespondToThrust()//checking input for thrust
    {
        if (thrustIsPressed || Input.GetKey(KeyCode.Space))
        {
            Thrust();
        }
        else
        {
            audioSource.Stop();
            //thrustVFX.Stop();
        }
    }

    private void Thrust()/*by calling this method player could fly rocket 
                          * in upwards direction, also thrustSFX playing*/
    {
        //Debug.Log("thrust");
        fuelBar.FuelCountAndDisplay(consumption);
        rb.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(thrustSFX);
        }
        /*if (!thrustVFX.isPlaying)
        {
            thrustVFX.Play();
        }*/
    }

    private void RespondToRotate()
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

    private void Die()//method which load first level, when Player lost
    {
        
        Debug.Log("Dead");
        audioSource.Stop();
        audioSource.PlayOneShot(deathSFX);
        Invoke("LoadFirstLevel", 2f);
    }
    

    public int GetHealth()
    {
        return health;
    }
}