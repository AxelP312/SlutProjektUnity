using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CreateTiles : MonoBehaviour
{
    Tilemap Block;
    public Tile[] Tiles;
    private HotbarKeys hotbarKeys;
    public Item item;
    public Inventory inventory;

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
                if (inventory.ItemList[hotbarKeys.HotbarSlot - 1] != null)
                {
                    Block.SetTile(TilePos, inventory.ItemList[hotbarKeys.HotbarSlot - 1].tileName);
                }
            }
            
        }
    }
}
