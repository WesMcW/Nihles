using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject canvas;
    public GameObject p1, p2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            // end game
            p1.GetComponent<PlayerMovement>().enabled = false;
            p2.GetComponent<PlayerTwoMovement>().enabled = false;
            Time.timeScale = 0;
            canvas.GetComponent<checkForWin>().enableWinScreen();
        }
    }
}
