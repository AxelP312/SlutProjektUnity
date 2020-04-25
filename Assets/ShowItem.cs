using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowItem : MonoBehaviour
{
    public Inventory inventory;
    private List<GameObject> slots = new List<GameObject>();
    private Image image;
    public Item item; //TEST SAK

    // Start is called before the first frame update
    void Start()
    {

        //Den börjar med att den kollar i "Panel" efter alla direkta barn, dvs. slots1-slot9
        //Efter det kollar den i varje slot från 1-9 efter gameobjects med taggen "slot"

        /*Det som händer här är att den kollar i GameObjektet Panel efter alla direkta barn, vilket i det här fallet är
         Slot1, slot2 osv upp till Slot9. Men för varje slot som den kollar kollar den även dess Grandchildren. 
         Det vill säga att den kollar fört Slot1 och sedan kollar den Image. 
         Beroende på om Gameobjektet Image har taggen "slot" eller inte kommer avgöra om den läggs till i listan eller inte. 
         Listan är en lista som är GameObjekt*/
        foreach (Transform child in transform)
        {

            foreach(Transform Grandchild in child)
            {
                if (Grandchild.gameObject.tag == "slot")
                {
                    slots.Add(Grandchild.gameObject);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Kallar metoden, den kollar först vilket Item och vilken slot den ska uppdateras i. 
        SpriteChange(item, 0);
    }

    public void SpriteChange(Item item, int itemslot)
    {
        //Den kollar vilken plats i Slots som objektet ligger och tar sedan in bilden som ligger länkat till den genom ItemS (Scriptable object)
        image = slots[itemslot].GetComponent<Image>(); //Vilken plats i inventoryn!!
        image.sprite = item.sprite; //Den ändrar sedan image.sprite till item.sprite, vilket är den sprite kopplat till itemet. 
    }
}
