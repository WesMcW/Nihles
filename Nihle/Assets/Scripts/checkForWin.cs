﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkForWin : MonoBehaviour
{
    public GameObject winScreen;

    public GameObject p1, p2;

    public void checkingWin()
    {
        if(p1.GetComponent<WinCondition>().hasWon && p2.GetComponent<WinCondition>().hasWon)
        {
            p1.GetComponent<PlayerMovement>().enabled = false;
            p2.GetComponent<PlayerTwoMovement>().enabled = false;

            Debug.Log("Yay you won");
            winScreen.SetActive(true);
            // show score
            // enable button navigation for win screen
        }
    }
}
