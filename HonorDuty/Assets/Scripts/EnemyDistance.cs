using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistance : MonoBehaviour
{

    PlayerController player;
    Vector2 target;
    Vector2 posEnemy;
    float velocity = 4f;
    public float shootingRange;
    public float fireRate = 3f;
    public float nextFireTime;
    public float followRange;
    [SerializeField] Transform enemy;
    [SerializeField] public int lifesEnemy = 30;
    [SerializeField] ArrowScript arrow;
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

        if (distance < followRange && distance > shootingRange)
        {
            rb.MovePosition(posEnemy);
            if (nextFireTime < Time.time) { 

                Instantiate(arrow, enemy.position, Quaternion.identity);
                nextFireTime = Time.time + fireRate;
            }
        }
    }
    public void TakeDamage()
    {
        lifesEnemy -= 1;
        if (lifesEnemy == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(enemy.position, followRange);
        Gizmos.DrawWireSphere(enemy.position, shootingRange);
         
    }
}
