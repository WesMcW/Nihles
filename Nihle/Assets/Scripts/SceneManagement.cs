using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagement : MonoBehaviour
{
    Scene currentScene;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        Debug.Log("Active scene name is: " + currentScene.name + "n/Active scene index: " + currentScene.buildIndex);
    }

    void Update()
    {
        //If it is a level:
        //Once condition is met, go to the next level
        //SceneManager.LoadScene(currentScene.buildIndex + 1, LoadSceneMode.Single);

    }
}
