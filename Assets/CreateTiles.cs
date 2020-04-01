using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CreateTiles : MonoBehaviour
{
    Tilemap Block;
    public Tile Test;
    // Start is called before the first frame update
    void Start()
    {
        Block = GameObject.Find("Karta").GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        //Högerklick = 1
        if(Input.GetMouseButton(1))
        {
            Vector3 MusPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(MusPos);

            Vector3Int TilePos = Block.WorldToCell(MusPos);
            Debug.Log(MusPos);

            //BYT Test MOT EN TILE
            Block.SetTile(TilePos, Test);
        }
    }
}
