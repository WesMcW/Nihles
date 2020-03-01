using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public bool isPaused = false;
    public GameObject pauseScreen;
    public Button[] pauseScreenBtns;

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
        setButtonNavs();
    }

    void setButtonNavs()
    {
        Navigation replayNav = new Navigation();
        replayNav.mode = Navigation.Mode.Explicit;
        replayNav.selectOnDown = pauseScreenBtns[1];
        pauseScreenBtns[0].navigation = replayNav;

        Navigation menuNav = new Navigation();
        menuNav.mode = Navigation.Mode.Explicit;
        menuNav.selectOnUp = pauseScreenBtns[0];
        pauseScreenBtns[1].navigation = menuNav;


        GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(pauseScreenBtns[0].gameObject);
    }
}
