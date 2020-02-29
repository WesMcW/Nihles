﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartup : MonoBehaviour
{
    public bool isFreePlay = false;
    public GameObject collectables;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("Collectables") == "false")
        {
            isFreePlay = true;
            collectables.SetActive(false);
        }
    }
}