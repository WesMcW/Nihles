using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class worldChange : MonoBehaviour
{
    public TileBase happy;
    public TileBase sad;

    private void Start() {
        Tilemap tiles = GetComponent<Tilemap>();
        tiles.SwapTile(happy, sad);
    }
}
