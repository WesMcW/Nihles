using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public bool isPaused = false;
    public GameObject pauseScreen;
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

    public void Resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
