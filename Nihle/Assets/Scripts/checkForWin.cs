using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class checkForWin : MonoBehaviour
{
    public bool isEndless;

    public Sprite star;

    public GameObject winScreen;
    public GameObject scoreImg;

    public WinCondition p1Win, p2Win;
    public GameObject p1, p2;

    public Button[] winScreenBtns;

    public Text endlessScoreTxt;

    public void checkingWin()
    {
        if(p1Win.hasWon && p2Win.hasWon)
        {
            p1.GetComponent<PlayerMovement>().disableThings();
            p2.GetComponent<PlayerTwoMovement>().disableThings();

            Debug.Log("Yay you won");
            Invoke("enableWinScreen", 0.5F);
        }
    }

    void setButtonNavs()
    {
        if (!isEndless)
        {
            Navigation nextNav = new Navigation();
            nextNav.mode = Navigation.Mode.Explicit;
            nextNav.selectOnLeft = winScreenBtns[2];
            nextNav.selectOnRight = winScreenBtns[1];
            winScreenBtns[0].navigation = nextNav;

            Navigation replayNav = new Navigation();
            replayNav.mode = Navigation.Mode.Explicit;
            replayNav.selectOnLeft = winScreenBtns[0];
            replayNav.selectOnRight = winScreenBtns[2];
            winScreenBtns[1].navigation = replayNav;

            Navigation menuNav = new Navigation();
            menuNav.mode = Navigation.Mode.Explicit;
            menuNav.selectOnLeft = winScreenBtns[1];
            menuNav.selectOnRight = winScreenBtns[0];
            winScreenBtns[2].navigation = menuNav;
        }
        else
        {
            Navigation replayNav = new Navigation();
            replayNav.mode = Navigation.Mode.Explicit;
            replayNav.selectOnLeft = winScreenBtns[1];
            replayNav.selectOnRight = winScreenBtns[1];
            winScreenBtns[0].navigation = replayNav;

            Navigation menuNav = new Navigation();
            menuNav.mode = Navigation.Mode.Explicit;
            menuNav.selectOnLeft = winScreenBtns[0];
            menuNav.selectOnRight = winScreenBtns[0];
            winScreenBtns[1].navigation = menuNav;
        }

        GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(winScreenBtns[0].gameObject);
    }

    public void nextLevel()
    {
        SceneManagement.currInstance.nextLevel();
    }

    public void restart()
    {
        SceneManagement.currInstance.restartLevel();
    }

    public void toTitle()
    {
        SceneManagement.currInstance.returnToTitle();
    }

    public void enableWinScreen()
    {
        winScreen.SetActive(true);
        setButtonNavs();

        if (!isEndless)
        {
            if (GetComponent<LevelStartup>().isFreePlay) scoreImg.SetActive(false);
            else
            {
                // set score
                scoreImg.SetActive(true);

                int finalScore = p1.GetComponent<PlayerInteract>().showScore();
                if (finalScore > 0)
                {
                    scoreImg.transform.GetChild(0).GetComponent<Image>().sprite = star;
                    if (finalScore > 1)
                    {
                        scoreImg.transform.GetChild(1).GetComponent<Image>().sprite = star;
                        if (finalScore > 2)
                        {
                            scoreImg.transform.GetChild(2).GetComponent<Image>().sprite = star;
                        }
                    }
                }

                int currLevel = SceneManager.GetActiveScene().buildIndex;
                if (PlayerPrefs.GetInt("MaxLevel") < currLevel + 1) PlayerPrefs.SetInt("MaxLevel", currLevel + 1);

                string playPref = "Level" + currLevel + "Score";
                Debug.Log(playPref + ", " + finalScore);
                if (finalScore > PlayerPrefs.GetInt(playPref)) PlayerPrefs.SetInt(playPref, finalScore);
            }
        }

        else
        {
            int score = Mathf.RoundToInt(GameObject.Find("EndlessManager").GetComponent<StartEndless>().totalTime);
            endlessScoreTxt.text = "Final Score: " + score;
        }
    }
}
