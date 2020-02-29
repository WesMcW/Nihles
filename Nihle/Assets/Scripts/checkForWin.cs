using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkForWin : MonoBehaviour
{
    public GameObject winScreen;

    public WinCondition p1Win, p2Win;

    public void checkingWin()
    {
        if(p1Win.hasWon && p2Win.hasWon)
        {
            p1Win.GetComponent<PlayerMovement>().enabled = false;
            p2Win.GetComponent<PlayerTwoMovement>().enabled = false;

            Debug.Log("Yay you won");
            winScreen.SetActive(true);
            // show score
            // enable button navigation for win screen
        }
    }
}
