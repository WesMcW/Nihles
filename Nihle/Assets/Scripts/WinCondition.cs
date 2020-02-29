using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public bool isHappy;

    public checkForWin checkWin;
    public bool hasWon = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHappy)
        {
            if (collision.CompareTag("Player2"))
            {
                hasWon = true;
                checkWin.checkingWin();
            }
        }
        else
        {
            if(collision.CompareTag("Player1"))
            {
                hasWon = true;
                checkWin.checkingWin();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isHappy)
        {
            if (collision.CompareTag("Player2"))
            {
                hasWon = false;
            }
        }
        else
        {
            if (collision.CompareTag("Player1"))
            {
                hasWon = false;
            }
        }
    }
}
