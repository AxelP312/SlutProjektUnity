using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarKeys : MonoBehaviour
{

    public int HotbarSlot;
    // Start is called before the first frame update
    void Start()
    {
        HotbarSlot = 1;
    }

    // Update is called once per frame
    void Update()
    {
        HotbarSlot = TileDecider(HotbarSlot);
    }

    int TileDecider(int HotbarSlot)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            HotbarSlot = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            HotbarSlot = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            HotbarSlot = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            HotbarSlot = 4;

        }
        else
        {

        }
        return HotbarSlot;
    }
}
