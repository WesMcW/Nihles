using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public int playerNum;
    string interactButton;

    public int sadCollect, hapCollect;
    public int totalCollect, score;
    public GameObject otherPlayer;

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
        if(collision.gameObject.CompareTag("sadCollect") && playerNum == 1)
        {
            sadCollect++;
            totalIncrease();
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("hapCollect") && playerNum == 2)
        {
            hapCollect++;
            totalIncrease();
            Destroy(collision.gameObject);
        }
    }

    public void totalIncrease()
    {
        totalCollect++;
        otherPlayer.GetComponent<PlayerInteract>().totalCollect++;
    }

    //Give the final score
    public int showScore()
    {
        if(totalCollect == 6)
        {
            score = 3;
        }
        else if(totalCollect == 5 || totalCollect == 4)
        {
            score = 2;
        }
        else if(totalCollect == 3 || totalCollect == 2 || totalCollect == 1 || totalCollect == 0)
        {
            score = 1;
        }

        return score;
    }
}
