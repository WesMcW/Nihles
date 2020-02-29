using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneManagement : MonoBehaviour
{
    Scene currentScene;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        Debug.Log("Active scene name is: " + currentScene.name + "n/Current index is: " + currentScene.buildIndex);
    
    }

    void Update()
    {
        //If it is a level:
        //Once condition is met, go to the next level
        //SceneManager.LoadScene(currentScene.buildIndex + 1);

    }

    /* BELOW ARE METHODS FOR THE TITLE SCREEN */

    public void exitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void previousScene()
    {
        //load previos scene or "go back"
        if(SceneManager.GetActiveScene().buildIndex > 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void returnToTitle()
    {
        //load to title screen; assuming it is build index 0 for now
        SceneManager.LoadScene(0);
    }

    public void playLevel()
    {
        //if we are using text mesh pro this needs to be changed
        //may not need this method 
        Text buttonText = transform.Find("Text").GetComponent<Text>();

        SceneManager.LoadScene("Level " + buttonText.text);
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
