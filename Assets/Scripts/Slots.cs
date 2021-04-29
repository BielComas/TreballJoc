using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour
{
    PlayerShoot playerAmmo;
    [SerializeField] public InventoryScript inventory;
    public int i;
    private void Start()
    {
        playerAmmo = FindObjectOfType<PlayerShoot>();
    }
    private void Update()
    {
        Drop();
    }

    private void Awake()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
    }
    public void Drop()
    {
        foreach(Transform child in transform)
        {
            child.GetComponent<Spawn>().SpawnDroppedItem();
            if(child.tag == "buttonBomb")
            {
                playerAmmo.numBombs -= 1;
            }
            if(child.tag == "buttonShuriken")
            {
                playerAmmo.numShurikens -= 1;
            }
           Destroy(child.gameObject);
        }
    }
}
