﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPass : MonoBehaviour
{
    [SerializeField] GameObject barrier;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Destroy(barrier);
        }
    }
}
