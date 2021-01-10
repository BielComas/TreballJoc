﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBomb : MonoBehaviour
{
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            player.isHiden = true;
        }
    }
}
