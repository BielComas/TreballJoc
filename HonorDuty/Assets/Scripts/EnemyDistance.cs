using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistance : MonoBehaviour
{

    PlayerController player;
    Vector2 target;
    Vector2 posEnemy;
    float velocity = 4f;
    [SerializeField] Transform enemy;
    [SerializeField] public int lifesEnemy = 30;
    Rigidbody2D rb;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        target = new Vector2(player.transform.position.x, player.transform.position.y);
        posEnemy = Vector2.MoveTowards(rb.position, target, velocity * Time.deltaTime);
        distance = Vector2.Distance(target, posEnemy);

        if (distance < 10f)
        {
            rb.MovePosition(target);
        }
    }
    public void FollowPlayer()
    {

    }
    public void TakeDamage()
    {
        lifesEnemy -= 1;
        if (lifesEnemy == 0)
        {
            Destroy(gameObject);
        }
    }
}
