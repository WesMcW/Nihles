﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace swapper
{
    public class SwapLocations : MonoBehaviour
    {
        GameObject player1;
        GameObject player2;
        
        // Start is called before the first frame update
        void Start()
        {
            if (player1 == null)
                player1 = GameObject.FindGameObjectWithTag("Player1");
            if (player2 == null)
                player2 = GameObject.FindGameObjectWithTag("Player2");
        }

        void switchSpots()
        {
            /*
            Vector2 locOfP1 = player1.transform.position;
            Vector2 locOfP2 = player2.transform.position;
            player1.transform.position = locOfP2;
            player2.transform.position = locOfP1;
            */
            Worlds player1World = player1.GetComponent<PlayerStats>().myWorld;
            Worlds player2World = player2.GetComponent<PlayerStats>().myWorld;
            player1.GetComponent<PlayerStats>().myWorld = player2World;
            player2.GetComponent<PlayerStats>().myWorld = player1World;

        }
    }
}