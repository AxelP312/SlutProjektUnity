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
        /*I första framen hämtar jag min tilemap genom att använda GameObject.Find("Karta"), vilket letar efter ett gameobject med namnet karta
         * Den tar letar sedan efter ett gameobject med class/typ som står inne i klämmorna. I det här fallet är det en tilemap.
         Jag binder den sedan till variabeln Block.*/
        Block = GameObject.Find("Karta").GetComponent<Tilemap>();
    }

    void Update()
    {
        //If sats som startar om man klickar på musknappen 1, vilket är högerklick. 
        if(Input.GetMouseButton(1))
        {
            //Referens till scriptet HotBarKeys.cs för att kunna använda variabeln HotbarSlot.
            hotbarKeys = GetComponent<HotbarKeys>();
            Debug.Log(hotbarKeys.HotbarSlot);

            //Den tar sedan in muspekarens position och kollar vilka koordinater den har i Huvudkameran, "Main Camera" och gör om den till en vectorn
            Vector3 MusPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Därefter tar den vectorn och kollar vilken Tilemap plats, vilken ruta i rutnätet som den koordinaten ligger i.
            Vector3Int TilePos = Block.WorldToCell(MusPos);

            /*Den här if-satsen gör att om man är på hotbarSlot1, kan den inte sätta ut ett block då hotbarslot 1 är endast till att förstöra block. 
              Om det inte är på plats 1 går den vidare till nästa if-sats som kollar om inventory.ItemList[hotbarKeys.HotbarSlot - 1 inte är null.
              Den använder ItemList från scriptet Inventory och kollar om platsen i sin hotbar man är. Om man är på hotbarSlot 2, tar den det -1 för att
              det ska stämma med hur arrayer och listor fungerar. Om man vill bygga med sitt tredje slot i sin hotbar, kollar den trejde platsen i listan
              efter ett item och så länge .tileName inte är null kommer det hända något.

              Det som händer är att den använder Block, vilket är vår Tilemap, använder unitys metod för SetTile, Tar in TilePos, vilket är vektorn
              som vi fick från musens position som blev omvanlad till vilken ruta den var i. Det blocket som den ska lägga ut använder den då 
              scriptet Inventorys Lista, Itemlist och tar in vilken slot man är i från hotbarKeys scriptet -1, för att matcha i listan och sist men inte minst 
              .tileName. tileName bestämmer vilket block som läggs ut. 
             */
            if (hotbarKeys.HotbarSlot == 1){}
            else
            {
                if (inventory.ItemList[hotbarKeys.HotbarSlot - 1] != null)
                {
                    if(inventory.ItemList[hotbarKeys.HotbarSlot - 1].tileName != null)
                    {
                        Block.SetTile(TilePos, inventory.ItemList[hotbarKeys.HotbarSlot - 1].tileName);
                    }
                    
                }
            }
            
        }
    }
}
