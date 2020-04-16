using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyTiles : MonoBehaviour
{
    private float BlockDelay = 0;
    Tilemap Block;
    private HotbarKeys hotbarKeys;


    void Start()
    {
        Block = GameObject.Find("Karta").GetComponent<Tilemap>();
    }

    void Update()
    {
        BlockDelay += Time.deltaTime;
        hotbarKeys = GetComponent<HotbarKeys>();

        if (Input.GetMouseButton(0) && BlockDelay > 0.5 && hotbarKeys.HotbarSlot == 1)
        {
            Vector3 SnällaFungera = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(SnällaFungera);

            Vector3Int TilePos = Block.WorldToCell(SnällaFungera);
            Debug.Log(SnällaFungera);

            Block.SetTile(TilePos, null);
            BlockDelay = 0;
        }
    }
}
