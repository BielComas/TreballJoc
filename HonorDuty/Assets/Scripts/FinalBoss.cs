using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    [SerializeField] Transform boss;
    Animator anim;
    PlayerController player;
    ManagerLevel lh;
    Vector2 posBoss;
    Rigidbody2D rb;
    float distance;
    Vector2 target;
    int lifesEnemy = 200;
    int currentLifes;
    float nextTpTime;
    float tpRate = 3f;
    public float velocity = 7f;
    public float followRange;
    public float damageRange;
    public float attackRange = 2f;
    public LayerMask playerLayer;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
        currentLifes = lifesEnemy;
        lh = FindObjectOfType<ManagerLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        target = new Vector2(player.transform.position.x, player.transform.position.y);
        posBoss = Vector2.MoveTowards(rb.position, target, velocity * Time.deltaTime);
        distance = Vector2.Distance(target, posBoss);


        if(target.x > posBoss.x)
        {
            boss.GetComponent<SpriteRenderer>().flipX = false;
        }
        if(target.x < posBoss.x)
        {
            boss.GetComponent<SpriteRenderer>().flipX = true;
        }
        if(distance < followRange && distance > attackRange)
        {
            anim.SetBool("running", true);
            rb.MovePosition(posBoss);

        }
        if (distance < attackRange)
        {
            if (nextTpTime < Time.time)
            {
                Attack();
                nextTpTime = Time.time + tpRate;
            }
        }
    }

    public void Attack()
    {
        anim.SetTrigger("attack");
        rb.MovePosition(target);
        Collider2D [] playerCol = Physics2D.OverlapCircleAll(boss.position, damageRange, playerLayer);

        foreach (Collider2D players in playerCol)
        {
            if (players.name == player.name)
            {
                if (player.canTakeDamage == true)
                {
                    players.GetComponent<PlayerController>().TakeDamage(30);
                }
            }
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
        anim.SetTrigger("death");
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
        lh.LoadWin();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(boss.position, followRange);
        Gizmos.DrawWireSphere(boss.position, attackRange);
        Gizmos.DrawWireSphere(boss.position, damageRange);
    }
}
