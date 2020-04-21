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
        SpriteChange(item, 1);
    }

    public void SpriteChange(Item item, int itemslot)
    {
        image = slots[itemslot].GetComponent<Image>(); //Vilken plats i inventoryn!!
        image.sprite = item.sprite;
    }
}
