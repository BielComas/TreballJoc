using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private InventoryScript inventory;
    PlayerShoot playerAmmo;
    public GameObject ItemButton;
    // Start is called before the first frame update
    void Start()
    {
        playerAmmo = FindObjectOfType<PlayerShoot>();
        inventory = FindObjectOfType<InventoryScript>();      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            for(int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    //pots agafar l'objecte
                    inventory.isFull[i] = true;
                    Instantiate(ItemButton, inventory.slots[i].transform, false);
                    if (ItemButton.name == "ButtonShuriken")
                    {
                        playerAmmo.numShurikens += 1;
                    }
                    if (ItemButton.name == "ButtonBomb")
                    {
                        playerAmmo.numBombs += 1;
                    }
                    Destroy(gameObject);
                    break;
                    
                }
            }
        }
    }
}
