using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    private void Update()
    {
        DebugLoadLevel();
    }


    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadRules()
    {
        SceneManager.LoadScene("Rules");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    
    public void LoadNextScnene()
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

    private void DebugLoadLevel()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadNextScnene();
        }
    }

}
