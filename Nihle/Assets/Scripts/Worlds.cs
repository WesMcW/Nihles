using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worlds : MonoBehaviour
{
    [SerializeField]
    bool happy = false;
    [SerializeField]
    GameObject myBretheren;
    public bool getHappy()
    {
        return happy;
    }
}
