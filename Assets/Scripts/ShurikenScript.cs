﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenScript : MonoBehaviour
{
    EnemyDistance enemyDistance;
    Rigidbody2D rb;
    EnemyMelee enemyMelee;
    FinalBoss boss;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boss = FindObjectOfType<FinalBoss>();
        enemyDistance = FindObjectOfType<EnemyDistance>();
        enemyMelee = FindObjectOfType<EnemyMelee>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "map")
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Boss")
        {
            FindObjectOfType<AudioManager>().Play("Enemy Distance Hit");
            boss.TakeDamage(40);
            Destroy(gameObject);
        }
        if (collision.transform.tag == "EnemyDistance")
        {
            FindObjectOfType<AudioManager>().Play("Enemy Distance Hit");
            enemyDistance.TakeDamage(20);
            Destroy(gameObject);
        }
        if (collision.transform.tag == "EnemyMelee")
        {
            FindObjectOfType<AudioManager>().Play("Enemy Distance Hit");
            enemyMelee.TakeDamage(20);
            Destroy(gameObject);
        }
        if (collision.transform.tag == "wall")
        {
            Destroy(gameObject);
        }
    }
}
