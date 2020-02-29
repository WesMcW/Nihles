using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlock : MonoBehaviour
{
    public bool isHappy;
    public GameObject myCopy;

    // Update is called once per frame
    void Update()
    {

    }

    public void pushedBlock(int playerNum)
    {
        // check for player type if can push
        if (playerNum == 2 && isHappy)
        {
            if (transform.position.x != (0 - myCopy.transform.position.x))
            {
                Debug.Log("moved " + gameObject.name);
                myCopy.transform.position = new Vector3(0 - transform.position.x, transform.position.y, 0);
            }
        }
        else if(playerNum == 1 && !isHappy)
        {
            if (transform.position.x != (0 - myCopy.transform.position.x))
            {
                Debug.Log("moved " + gameObject.name);
                myCopy.transform.position = new Vector3(0 - transform.position.x, transform.position.y, 0);
            }
        }
        else
        {
            transform.position = new Vector3(0 - myCopy.transform.position.x, myCopy.transform.position.y, 0);
        }
    }
}
