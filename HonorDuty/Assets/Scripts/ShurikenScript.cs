using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenScript : MonoBehaviour
{
    EnemyDistance enemyDistance;
    FinalBoss boss;
    // Start is called before the first frame update
    void Start()
    {
        boss = FindObjectOfType<FinalBoss>();
        enemyDistance = FindObjectOfType<EnemyDistance>();

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
            boss.TakeDamage(40);
            Destroy(gameObject);
        }
        if (collision.transform.tag == "enemy")
        {
            enemyDistance.TakeDamage(20);
            Destroy(gameObject);
        }
    }
}
