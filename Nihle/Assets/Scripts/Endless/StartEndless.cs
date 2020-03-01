using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEndless : MonoBehaviour
{
    public float startTime;
    public bool running;
    float timeMove = 0;

    public GameObject movingCamera;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("startGame", startTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            timeMove += (Time.deltaTime / 2);
            movingCamera.transform.position = new Vector3(0, timeMove, -10);
        }
    }

    void startGame()
    {
        running = true;
        GetComponent<GenerateWalls>().startInvoke();
    }
}
