﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public int playerNum;
    string interactButton;

    // Start is called before the first frame update
    void Start()
    {
        if (playerNum == 1) interactButton = "PlayerOneInteract";
        else interactButton = "PlayerTwoInteract";
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PushBlock"))
        {
            collision.gameObject.GetComponent<PushBlock>().pushedBlock(playerNum);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
