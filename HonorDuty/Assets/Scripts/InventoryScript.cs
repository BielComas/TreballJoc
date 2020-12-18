using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{

    private bool inventoryEnable;

    public GameObject inventory;

    private int allSlots;

    private int enableSlots;

    private GameObject[] slot;

    public GameObject slotHolder;





    void Start()
    {
        //The slots of SlotHolder count teh number of childs 
        //inside the SlotHolder.
        allSlots = slotHolder.transform.childCount;

        //Save all slots inside SlotHolder.
        slot = new GameObject[allSlots];

        //Wander the slots and the array save items.
        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
        }
    }

    void Update()
    {
        //If you press i, show inventory
        if (Input.GetKeyDown("i"))
        {
            //And if not enable not show, and if enable show inventory.
            inventoryEnable = !inventoryEnable;
        }

        //And the inventory it's true, active inventory
        if (inventoryEnable == true)
        {
            inventory.SetActive(true);
        }
        else
        {
            //If not active the inventory it's false.
            inventory.SetActive(false);
        }


    }
}
