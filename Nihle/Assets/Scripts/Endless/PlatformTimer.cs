using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTimer : MonoBehaviour
{
    public float lifespan = 120F;

    // Update is called once per frame
    void Update()
    {
        lifespan -= Time.deltaTime;
        if (lifespan < 0) Destroy(gameObject);
    }
}
