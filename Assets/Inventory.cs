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
        /*Det som händer här är att den går igenom varje Item från ItemList, vilket är listan vi skapat
         och kollar om det är null eller inte. Är det null körs det inte och pos blir +1, men om det inte är null körs det.
         Det som händer är att den kallar metoden SpriteChange från scriptet ShowItem.cs och tar in paramentern Item det är.
         Den tar även in parametern Pos, vilket går +1 för varje item i listan då vi vill att spritsen inte ska ligga över varandra.
        */
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
