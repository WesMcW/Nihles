using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkForWin : MonoBehaviour
{
    public Sprite star;

    public GameObject winScreen;
    public GameObject scoreImg;

    public WinCondition p1Win, p2Win;
    public GameObject p1, p2;

    public Button[] winScreenBtns;

    public void checkingWin()
    {
        if(p1Win.hasWon && p2Win.hasWon)
        {
            p1.GetComponent<PlayerMovement>().enabled = false;
            p2.GetComponent<PlayerTwoMovement>().enabled = false;

            Debug.Log("Yay you won");
            winScreen.SetActive(true);
            setButtonNavs();

            if (GetComponent<LevelStartup>().isFreePlay) scoreImg.SetActive(false);
            else
            {
                // set score
                scoreImg.SetActive(true);

                int finalScore = p1.GetComponent<PlayerInteract>().showScore();
                if(finalScore > 0)
                {
                    scoreImg.transform.GetChild(0).GetComponent<Image>().sprite = star;
                    if(finalScore > 1)
                    {
                        scoreImg.transform.GetChild(1).GetComponent<Image>().sprite = star;
                        if(finalScore > 2)
                        {
                            scoreImg.transform.GetChild(2).GetComponent<Image>().sprite = star;
                        }
                    }
                }
            }
        }
    }

    void setButtonNavs()
    {
        Navigation nextNav = new Navigation();
        nextNav.mode = Navigation.Mode.Explicit;
        nextNav.selectOnUp = winScreenBtns[2];
        nextNav.selectOnDown = winScreenBtns[1];
        winScreenBtns[0].navigation = nextNav;

        Navigation replayNav = new Navigation();
        replayNav.mode = Navigation.Mode.Explicit;
        replayNav.selectOnUp = winScreenBtns[0];
        replayNav.selectOnDown = winScreenBtns[2];
        winScreenBtns[1].navigation = replayNav;

        Navigation menuNav = new Navigation();
        menuNav.mode = Navigation.Mode.Explicit;
        menuNav.selectOnUp = winScreenBtns[1];
        menuNav.selectOnDown = winScreenBtns[0];
        winScreenBtns[2].navigation = menuNav;

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
}
