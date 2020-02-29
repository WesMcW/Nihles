using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkForWin : MonoBehaviour
{
    public GameObject winScreen;

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
            // show score
            // enable button navigation for win screen
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
}
