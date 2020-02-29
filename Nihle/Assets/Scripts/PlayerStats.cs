using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    float maxDrive = 50;
    float currDrive = 0;
    [SerializeField]
    string player = "", player1 = "Player1", player2 = "Player2";

    float driveMultiplier = 1f;
    public Worlds myWorld;

    // Start is called before the first frame update
    void Start()
    {
        myWorld = GetComponentInParent<Worlds>();
        player = gameObject.tag;

        if (gameObject.CompareTag(player2))
        {
            currDrive = 0;
        }
        if (gameObject.CompareTag(player1))
        {
            currDrive = 50;
        }
    }

    // Update is called once per frame
    void Update()
    {
        do_I_die();
        if ((myWorld.getHappy() && (player == player2)) || !myWorld.getHappy() && (player == player1))
        {
            DeathToMe();
        }

    }
    void DeathToMe()
    {
        if (player == player2)
        {
            if (currDrive >= maxDrive)
            {
                //Gets too excited and dies
                currDrive += driveMultiplier;
            }
        }
        if (player == player1)
        {
            if (currDrive <= 0)
            {
                //Gets too depressed and dies
                currDrive -= driveMultiplier;
            }
        }
    }
    void do_I_die()
    {
        if (player == player2)
        {
            if (currDrive >= maxDrive)
            {
                //Gets too excited and dies
                Destroy(gameObject);
            }
        }
        if (player == player1)
        {
            if (currDrive <= 0)
            {
                //Gets too depressed and dies
                Destroy(gameObject);
            }
        }
    }


}
