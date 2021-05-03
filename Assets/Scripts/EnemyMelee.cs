using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class EnemyMelee : MonoBehaviour
{
    PlayerController player;
    Vector2 target;
    Vector2 posEnemy;
    Vector2 startPos;
    float velocity = 10f;
    public float hitRange;
    public float hitRate = 3f;
    public float nextHitTime;
    public float followRange;
    [SerializeField] Transform enemy;
    public int lifesEnemy = 100;
    int currentLifes;
    [SerializeField] ArrowScript arrow;
    Rigidbody2D rb;
    Animator anim;
    float distance;
    private bool canAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
        anim = gameObject.GetComponent<Animator>();
        startPos = rb.position;
        currentLifes = lifesEnemy;    
    }
    private void Update()
    {
        target = new Vector2(player.transform.position.x, player.transform.position.y);
        posEnemy = Vector2.MoveTowards(rb.position, target, velocity * Time.deltaTime);
        distance = Vector2.Distance(target, posEnemy);

        if (target.x > posEnemy.x)
        {
            enemy.GetComponent<SpriteRenderer>().flipX = false;
        }
        if(target.x < posEnemy.x)
        {
            enemy.GetComponent<SpriteRenderer>().flipX = true;
        }
        if(distance < followRange && distance > hitRange && canAttack)
        {
            anim.SetBool("Running", true);
            rb.MovePosition(posEnemy);
           
        }
        if (distance <= hitRange)
        {
            if (nextHitTime < Time.time)
            {
                Attack();
                nextHitTime = Time.time + hitRate;
            }
        }
        if (player.isHiden == true)
        {
            canAttack = false;
            posEnemy = Vector2.MoveTowards(rb.position, startPos, velocity * Time.deltaTime);
            if(rb.position == startPos)
            {
                anim.SetBool("Running", false);
            }
        }


    }
    public void Attack()
    {
        FindObjectOfType<AudioManager>().Play("Melee Attak");
        anim.SetTrigger("attack");
        if (player.canTakeDamage == true)
        {
            player.TakeDamage(15);
        }
    }
   

 
    public void TakeDamage(int quantity)
    {
        anim.SetTrigger("damage");
        currentLifes -= quantity;
        if (currentLifes <= 0)
        {
            StartCoroutine(Die());
        }
    }
    IEnumerator Die()
    {
        FindObjectOfType<AudioManager>().Play("Enemy Die");
        anim.SetBool("die", true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(enemy.position, followRange);
        Gizmos.DrawWireSphere(enemy.position, hitRange);
    }
}
