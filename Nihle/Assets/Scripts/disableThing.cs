using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableThing : MonoBehaviour
{
    public void turnOff()
    {
        gameObject.SetActive(false);
    }
}
