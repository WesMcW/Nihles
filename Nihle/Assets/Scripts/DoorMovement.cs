using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    public GameObject otherDoor;
    Animator myAnim, otherAnim;

    public GameObject usedDoor;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        otherAnim = otherDoor.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void teleport()
    {
        usedDoor.transform.position = otherDoor.transform.position;
    }
}
