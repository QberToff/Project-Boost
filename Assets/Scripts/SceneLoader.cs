using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{

    private void Update()
    {
        DebugLoadLevel();
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

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadSecondLevel()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void LoadThirdLevel()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void LoadFourthLevel()
    {
        SceneManager.LoadScene("Level 4");
    }

}
