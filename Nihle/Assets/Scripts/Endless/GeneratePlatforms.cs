﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatforms : MonoBehaviour
{
    public GameObject[] sadPrefabs;
    public GameObject[] happyPrefabs;
    Vector3Int placement;

    int sadPick = -1, happyPick = -1;

    // Start is called before the first frame update
    void Start()
    {
        placement = new Vector3Int(-9, -4, 0);
        startPlatforms();
        startPlatforms();
        startPlatforms();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startPlatforms()
    {
        sadPick = chooseRandom(sadPick);
        Instantiate(sadPrefabs[sadPick], placement, Quaternion.identity);

        // place happy pick, check if its special or not

        placement = new Vector3Int(-9, placement.y + 4, 0);
    }

    int chooseRandom(int pick)
    {
        pick = Random.Range(0, sadPrefabs.Length);
        return pick;
    }
}
