using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Item[] ItemList = new Item[9];
    public ShowItem showitem;

    // Start is called before the first frame update
    void Start()
    {

        int pos = 0;
        foreach (Item item in ItemList)
        {
            if(item != null) 
            {
                showitem.SpriteChange(item, pos);
            }
            pos++;
        }
    }

    // Update is called once per frame
    void Update()
    {}

}
