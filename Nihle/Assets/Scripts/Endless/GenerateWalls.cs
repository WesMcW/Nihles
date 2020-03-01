using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateWalls : MonoBehaviour
{
    public Tilemap happyTiles, sadTiles;
    public Tile[] sadWalls;
    public Tile[] happyWalls;
    public int sadPick = -1, happyPick = -1;

    Vector3Int placeHere;  //(0, 5), -10. 9

    // Start is called before the first frame update
    void Start()
    {
        placeHere = new Vector3Int(-1, 5, 0);
        InvokeRepeating("placeTiles", 0, 1F);
    }

    public void startInvoke()
    {
        InvokeRepeating("placeTiles", 0, 1F);
    }

    void placeTiles()
    {
        sadPick = pickNewTile(sadPick);
        happyPick = pickNewTile(happyPick);

        sadTiles.SetTile(placeHere, sadWalls[sadPick]);
        sadTiles.SetTile(new Vector3Int(placeHere.x - 9, placeHere.y, 0), sadWalls[sadPick]);

        happyTiles.SetTile(new Vector3Int(placeHere.x + 1, placeHere.y, 0), happyWalls[happyPick]);
        happyTiles.SetTile(new Vector3Int(placeHere.x + 10, placeHere.y, 0), happyWalls[happyPick]);

        placeHere = new Vector3Int(placeHere.x, placeHere.y + 1, 0);
    }

    int pickNewTile(int pick)
    {
        if (pick != 2)
        {
            pick = Random.Range(0, 6);
            if (pick > 2) pick = 0;
        }
        else pick = 3;
        return pick;
    }
}
