using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyTiles : MonoBehaviour
{
    Tilemap Block;
    private float BlockDelay = 0;
    private HotbarKeys hotbarKeys;
    public Inventory inventory;
    public Item[] items;
    /*1. Bestämmer att Block ska vara en Tilemap
      2. Sätter en float till public, vilket går att redigera i unity undertiden man spelar
      3. Referens till Scriptet HotbarKeys
     */



    void Start()
    {
        /*I första framen hämtar jag min tilemap genom att använda GameObject.Find("Karta"), vilket letar efter ett gameobject med namnet karta
         * Den tar sedan in __ och tar in GameObjectets typ. I det här fallet är det en tilemap.
         Jag binder den sedan till variabeln Block.*/
        Block = GameObject.Find("Karta").GetComponent<Tilemap>();

    }

    void Update()
    {
        /*Här har jag yttligare en time.deltatime då jag vill att det ska fungera på alla framerates, den tar 1/FPS, vilket gör att
        En sekund på 30 fps är lika lång tid som en sekund på 60fps.


        Jag har även refererat scriptet HotBarKeys.cs för att kunna använda variabeln HotbarSlot.
        */
        BlockDelay += Time.deltaTime;
        hotbarKeys = GetComponent<HotbarKeys>();

        /*Den här if-satsen kollar om man klickar på Musknappen 0, vilket är leftclick, den tar in BlockDelay, vilket är Time.deltaTime
         och den kollar även om HotbarSlot från HotbarKeys scriptet är på plats 1. 

        Den tar sedan in muspekarens position och kollar vilka koordinater den har i Huvudkameran, "Main Camera" och gör om den till en vectorn
        Därefter tar den vectorn och kollar vilken Tilemap plats, vilken ruta i rutnätet som den koordinaten ligger i.
        Det gör att man har rätt ruta i rutnätet och eftersom vi vill ta sönder en tile sätter vi den sedan till null.
        

        Den sätter även BlockDelay till 0 då vi vill att man inte bara ska kunna spamklicka på alla tiles utan att det ska finnas en delay att man ska förstöra block på.
        Det är därför man har BlockDelay > 0.5, vilket gör att den inte förstörs om 0.5s inte har passerat
         */
        if (Input.GetMouseButton(0) && BlockDelay > 0.5 && hotbarKeys.HotbarSlot == 1)
        {
            Vector3 SnällaFungera = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(SnällaFungera);

            Vector3Int TilePos = Block.WorldToCell(SnällaFungera);
            Debug.Log(SnällaFungera);

            Debug.Log(Block.GetTile(TilePos));

            //bool som stoppar om man har hittat ett item
            bool Founditem = false;
            //For-loop som kollar varje plats.
            for (int i = 0; i < items.Length; i++)
            {
                if(Founditem) //Om ett item har lagts till hoppar den ur loopen. 
                {
                    break;
                }
                /*Den här delen kollar om TilePos är lika med ett item i "ItemS", om det finn en tile med ett identiskt tileName.
                 * Den kommer då gå vidare om den hittar något, vilket gör att om man slår luften kommer inget hända. 
                 * Det som händer efter det är att den kollar efter en plats som håller null, finns det en plats med null kommer for-loopen aktiveras.
                 * For-loopen kollar då vilken plats som är null, vilket därefter kollar vilken plats som är null och lägga till den tile som var identisk till den plats i arrayen. 
                 * Därefter körs metoden SpriteChange från scriptet ShowItem.cs, vilket tar in vilket item det är samt vilken plats i listan det var. 
                 * Den lägger byter även boolen till True, vilket gör att for-loopen inte körs igenom för alla tiles och lägger till en tile på alla platser när man förstör en. 
                 */
                if(Block.GetTile(TilePos) == items[i].tileName)
                {
                    if (inventory.ItemList.Contains(null))
                    {
                        for (int j = 0; j < inventory.ItemList.Length; j++)
                        {

                            if(inventory.ItemList[j] == null)
                            {
                                inventory.ItemList[j] = items[i];
                                inventory.showitem.SpriteChange(items[i], j);
                                Founditem = true;
                                break;
                            }
                        }
                    }
                        
                }
            }
            /*Block.SetTile(TilePos, null);
             * Den tar in vilken Tilemap man pratar om, använder unitys metod SetTile där man tar in en VectorPosition och en tile. 
             */
            Block.SetTile(TilePos, null);
            BlockDelay = 0;
        }
    }
}
