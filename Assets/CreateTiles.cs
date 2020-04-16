using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CreateTiles : MonoBehaviour
{
    Tilemap Block;
    public Tile[] Tiles;
    public int Wah = 1;
    private HotbarKeys hotbarKeys;

    void Start()
    {
        Block = GameObject.Find("Karta").GetComponent<Tilemap>();
    }

    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            hotbarKeys = GetComponent<HotbarKeys>();
            Debug.Log(hotbarKeys.HotbarSlot);
            Vector3 MusPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3Int TilePos = Block.WorldToCell(MusPos);

            if(hotbarKeys.HotbarSlot == 1)
            {}
            else
            {
                Block.SetTile(TilePos, Test(hotbarKeys.HotbarSlot));
            }
            
        }
    }

    Tile Test(int Wah)
    {
        if(Wah == 1)
        {
            return Tiles[0];
        }
        else if(Wah == 2)
        {
            return Tiles[1];
        }
        else if (Wah == 3)
        {
            return Tiles[2];
        }
        else if (Wah == 4)
        {
            return Tiles[3];
        }
        else
        {
            return null;
        }
    }
}
