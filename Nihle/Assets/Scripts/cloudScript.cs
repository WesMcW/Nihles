using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudScript : MonoBehaviour
{
    public float timer;
    public GameObject cloud;

    private void Update() {
        timer -= Time.deltaTime;
        if(timer <= 0) {
            Instantiate(cloud, new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-5f, 5f)), Quaternion.identity);
            timer = 6f;
        }
    }
}
