using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartEndless : MonoBehaviour
{
    public float startTime;
    public bool running;
    float timeMove = 0;
    float faster = 2F;

    public Text scoreTxt;

    public float totalTime = 0;

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
            timeMove += (Time.deltaTime / faster);
            movingCamera.transform.position = new Vector3(0, timeMove, -10);

            totalTime += Time.deltaTime;
            scoreTxt.text = Mathf.RoundToInt(totalTime).ToString();
        }
    }

    void goFaster()
    {
        if (faster > 1F) faster -= 0.1F;
    }

    void startGame()
    {
        running = true;
        GetComponent<GenerateWalls>().startInvoke();
        GetComponent<GeneratePlatforms>().startInvoke();

        InvokeRepeating("goFaster", 30F, 10F);
    }
}
