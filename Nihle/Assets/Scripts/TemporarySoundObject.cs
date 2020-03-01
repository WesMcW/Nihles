using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporarySoundObject : MonoBehaviour
{
    float Timer = 360;
    private void Start()
    {
        GetComponent<AudioSource>().loop = false;
        GetComponent<AudioSource>().Play();
    }
    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer <=0)
        {
            Destroy(this);
        }
    }
}
