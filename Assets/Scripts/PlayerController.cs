using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform player;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    Vector2 direction;
    public float velocity = 3f;
    public float nextRollTime = 0f;
    public float rollRate = 3f;
    private bool isRunning = false;
    public bool isHiden = false;
    Rigidbody2D rb;
    [SerializeField] public Canvas inventory;
    private bool InventoryOpen = false;
    private State state;
    float rollVelocity;
    public LayerMask enemyLayer;
    Animator anim;
    private Vector3 rollDirection;
    [SerializeField] public int lifesPlayer = 100;
    public int currentHealth;
    public Text healthPoints;
    public bool canTakeDamage = true;
    ManagerLevel lh;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = lifesPlayer;
        state = State.Normal;
        rb = player.GetComponent<Rigidbody2D>();
        inventory.enabled = false;
        anim = player.GetComponent<Animator>();
        anim.SetBool("roll", false);
        lh = FindObjectOfType<ManagerLevel>();
    }
    private enum State
    {
        Normal,
        DodgeRollState,
    }
    // Update is called once per frame
    void Update()
    {
        
        switch (state)
        {
            case State.Normal:
                healthPoints.text = currentHealth.ToString();
                if (currentHealth < 0)
                {
                    healthPoints.text = "0";
                }
                canTakeDamage = true;
                direction.x = Input.GetAxis("Horizontal");
                direction.y = Input.GetAxis("Vertical");
                if (Input.GetKey(KeyCode.D))
                {
                    attackPoint.position = new Vector2(transform.position.x + 0.7f, transform.position.y);
                    anim.SetBool("running", true);
                   
                    player.GetComponent<SpriteRenderer>().flipX = false;
                }

                else
                {
                    anim.SetBool("running", false);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    attackPoint.position = new Vector2(transform.position.x - 0.7f, transform.position.y);
                    anim.SetBool("running", true);
                   
                    player.GetComponent<SpriteRenderer>().flipX = true;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    attackPoint.position = new Vector2(transform.position.x , transform.position.y - 0.7f);
                    anim.SetBool("running", true);
                }
                if (Input.GetKey(KeyCode.W))
                {
                    attackPoint.position = new Vector2(transform.position.x, transform.position.y + 0.7f);
                    anim.SetBool("running", true);
                 
                }

                ManageRoll();
                 
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    if (isRunning == false)
                    {
                        Run();
                    }
                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    velocity = 3f;
                    isRunning = false;
                }               
                
                if (Input.GetMouseButtonDown(0))
                {
                    if (Time.time >= nextAttackTime)
                    {
                        Attack();
                        nextAttackTime = Time.time + 1f / attackRate;
                    }
                }
                
                if (Input.GetKeyDown(KeyCode.I) && InventoryOpen == false)
                {
                    InventoryOpen = true;
                    inventory.enabled = true;
                    Time.timeScale = 0f;

                }
                else if (Input.GetKeyDown(KeyCode.I) && InventoryOpen == true)
                {
                    InventoryOpen = false;
                    inventory.enabled = false;
                    Time.timeScale = 1f;
                }
                break;
            case State.DodgeRollState:

                canTakeDamage = false;
                Roll();

                break;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * velocity * Time.deltaTime);
    }
    private void ManageRoll()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("roll");

            rollDirection = new Vector3(direction.x, direction.y, 0);
            rollVelocity = 25f;
            state = State.DodgeRollState;

        }
    }
    public void Attack()
    {
        FindObjectOfType<AudioManager>().Play("Attak");
        anim.SetTrigger("Attack");

        Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemie in hitEnemies)
        {
          
            if(enemie.name == "EnemyDistance")
            {
                enemie.GetComponent<EnemyDistance>().TakeDamage(20);
            }
            if(enemie.name == "EnemyMelee")
            {
                enemie.GetComponent<EnemyMelee>().TakeDamage(30);
            }
            if(enemie.name == "Boss")
            {
                enemie.GetComponent<FinalBoss>().TakeDamage(30);
            }
        }
    }
    private void Roll()
    {


        player.position += rollDirection * rollVelocity * Time.deltaTime;
        rollVelocity -= rollVelocity * 10f * Time.deltaTime;
        if (rollVelocity <= 5f)
        {
            state = State.Normal;
        }

    }
    public void TakeDamage(int quantity)
    {
        if (canTakeDamage == true)
        {
            canTakeDamage = false;
            anim.SetTrigger("damage");
            currentHealth -= quantity;
            canTakeDamage = true;
        }
        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }
    IEnumerator Die()
    {
        FindObjectOfType<AudioManager>().Play("Player Death");
        anim.SetBool("die", true);
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
        lh.DefeatLevel();
    }

    private void Run()
    {
        velocity += 2f;
        isRunning = true;
    }
    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}