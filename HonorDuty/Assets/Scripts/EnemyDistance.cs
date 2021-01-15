using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistance : MonoBehaviour
{

    PlayerController player;
    Vector2 target;
    Vector2 posEnemy;
    Vector2 startPos;
    float velocity = 4f;
    public float shootingRange;
    public float fireRate = 3f;
    public float nextFireTime;
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

    // Update is called once per frame
    void Update()
    {
        target = new Vector2(player.transform.position.x, player.transform.position.y);
        posEnemy = Vector2.MoveTowards(rb.position, target, velocity * Time.deltaTime);
        distance = Vector2.Distance(target, posEnemy);

        if (target.x < posEnemy.x)
        {
            enemy.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (target.x > posEnemy.x)
        {
            enemy.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (distance <= shootingRange && canAttack)
        {
            anim.SetBool("running", false);
            if (nextFireTime < Time.time)
            {

                anim.SetBool("attack", true);
            }

        }
        if (distance > followRange && distance < shootingRange)
        {
            anim.SetBool("running", true);
            rb.MovePosition(posEnemy);
        }
        if (player.isHiden == true)
        {
            canAttack = false;
            posEnemy = Vector2.MoveTowards(rb.position, startPos, velocity * Time.deltaTime);
            if (rb.position == startPos)
            {
                anim.SetBool("running", false);
            }
        }
        else if(player.isHiden == false)
        {
            canAttack = true;
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
        anim.SetBool("die", true);
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
    private void Shoot()
    {
        if (nextFireTime < Time.time)
        {
            float angle = Vector2.Angle(enemy.position, posEnemy);
            Instantiate(arrow, enemy.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
            anim.SetBool("attack", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(enemy.position, followRange);
        Gizmos.DrawWireSphere(enemy.position, shootingRange);

    }
}