using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{

    [SerializeField] int health = 2;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

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
            case "Finished":
                {
                    if (SceneManager.sceneCount == SceneManager.GetActiveScene().buildIndex)
                    {
                        SceneManager.LoadScene(0);
                    }
                    else
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }    
                   
                    break;
                }
            default:
                {
                    Debug.Log("Dead");
                    
                    if(health <= 0)
                    {
                        Debug.Log("Dead");
                        SceneManager.LoadScene(0);
                    }
                    else
                    {
                        health -= 1;
                    }


                    break;
                }
        }
    }

}