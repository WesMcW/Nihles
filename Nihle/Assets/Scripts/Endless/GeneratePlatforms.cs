using System.Collections;
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

    public void startInvoke()
    {
        InvokeRepeating("startPlatforms", 2.5F, 8.5F);
    }

    public void startPlatforms()
    {
        sadPick = chooseRandom(sadPick);
        Instantiate(sadPrefabs[sadPick], placement, Quaternion.identity);

        // place happy pick, check if its special or not
        happyPick = chooseRandom(happyPick);
        Instantiate(happyPrefabs[happyPick], new Vector3Int(1, placement.y, 0), Quaternion.identity);

        placement = new Vector3Int(-9, placement.y + 4, 0);
    }

    int chooseRandom(int pick)
    {
        pick = Random.Range(0, sadPrefabs.Length);
        return pick;
    }
}
