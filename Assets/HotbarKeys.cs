﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarKeys : MonoBehaviour
{

    public int HotbarSlot;

    void Start(){HotbarSlot = 1;}

    void Update()
    {
        HotbarSlot = TileDecider(HotbarSlot);
    }

    /*Metod som kollar tar in Vilken slot som används, kollar sedan vilken knapp som trycks ner.
     Om nummer 1 blir ner tryckt blir HotbarSlot 1, vilket i slutet blir return:ad och sätter HotbarSlot till den knapp man klickade.
    */
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
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            HotbarSlot = 5;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            HotbarSlot = 6;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            HotbarSlot = 7;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            HotbarSlot = 8;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            HotbarSlot = 9;

        }
        else
        {

        }
        return HotbarSlot;
    }
}
