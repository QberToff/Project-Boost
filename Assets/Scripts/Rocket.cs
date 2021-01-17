﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{

    // Start is called before the first frame update
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

                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    break;
                }
            default:
                {
                    Debug.Log("Dead");
                    break;
                }
        }
    }

}