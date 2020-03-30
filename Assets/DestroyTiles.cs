using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyTiles : MonoBehaviour
{

    Tilemap Block;
    // Start is called before the first frame update
    void Start()
    {
        //Block = GameObject.Find("Karta");
        Block = GameObject.Find("Karta").GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 MusPos = Input.mousePosition;
        Debug.Log(MusPos);
        if (Input.GetMouseButton(0))
        {
            Vector3Int TilePos = Tilemap.WorldToCell(MusPos);
            Block.SetTile(TilePos, null);
        }
        */

        if(Input.GetMouseButton(0))
        {
            Vector3 SnällaFungera = Camera.current.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(SnällaFungera);

            Vector3Int TilePos = Block.WorldToCell(SnällaFungera);
            Debug.Log(SnällaFungera);

            Block.SetTile(TilePos, null);
        }
    }
}
