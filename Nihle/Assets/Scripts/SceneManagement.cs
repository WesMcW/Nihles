using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneManagement : MonoBehaviour
{
    public static SceneManagement currInstance;
    public bool isPaused = false;
    public GameObject pauseMenuUI;

    public Scene currentScene;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        Debug.Log("Active scene name is: " + currentScene.name + "n/Current index is: " + currentScene.buildIndex);

        if (currInstance == null)
        {
            currInstance = this.GetComponent<SceneManagement>();
            DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject); 
    }

    void Update()
    {
        if (Input.GetButtonUp("Cancel") || Input.GetButtonUp("PlayerOnePause") || Input.GetButtonUp("PlayerTwoPause"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            if (isPaused)
            {
                isPaused = false;
                Resume();
            }
            else
            {
                isPaused = true;
                PauseGame();
            }
        }   
    }

    /* BELOW ARE METHODS FOR THE BUTTONS */

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

    public void nextLevel()
    {
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
       
}
