using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenScript : MonoBehaviour
{
    EnemyDistance enemyDistance;
    Rigidbody2D rb;
    EnemyMelee enemyMelee;
    float velocity = 10f;
    FinalBoss boss;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boss = FindObjectOfType<FinalBoss>();
        enemyDistance = FindObjectOfType<EnemyDistance>();
        enemyMelee = FindObjectOfType<EnemyMelee>();
    }
    private void Update()
    {
        transform.position = new Vector2(transform.position.x + 1 * velocity * Time.deltaTime, transform.position.y * Time.deltaTime);
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
        if (collision.transform.tag == "EnemyDistance")
        {
            enemyDistance.TakeDamage(20);
            Destroy(gameObject);
        }
        if (collision.transform.tag == "EnemyMelee")
        {
            enemyMelee.TakeDamage(20);
            Destroy(gameObject);
        }
    }
}
