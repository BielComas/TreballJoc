using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    PlayerController player;
    public GameObject target;
    float velocity = 20f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();    
        target = FindObjectOfType<PlayerController>().gameObject;
        Vector2 playerPos = (target.transform.position - transform.position).normalized * velocity;
        rb.velocity = new Vector2(playerPos.x, playerPos.y);
        FollowPlayer();
    }
    public void FollowPlayer()
    {
        Vector3 PlayerPos = target.transform.position;
        Vector3 obj = transform.position;
        Vector3 direction = PlayerPos - obj;
        direction.z = 0f;
        direction = direction.normalized;
        transform.up = direction;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            player.TakeDamage(20);
            Destroy(gameObject);

        }
        if (collision.transform.tag == "EnemyMelee")
        {
            Destroy(gameObject);
        }
        if (collision.transform.tag == "EnemyDistance")
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "wall")
        {
            Destroy(gameObject);
        }
    }


}
