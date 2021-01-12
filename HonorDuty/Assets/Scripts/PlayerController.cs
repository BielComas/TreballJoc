using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector2 direction;
    public float velocity = 3f;
    private float nextRollTime;
    private float rollRate = 3f;
    private bool isRunning = false;
    public bool isHiden = false;
    Rigidbody2D rb;
    [SerializeField] public Canvas inventory;
    private bool InventoryOpen = false;
    private State state;
    float rollVelocity;
    Animator anim;
    private Vector3 rollDirection;
    [SerializeField] int lifesPlayer = 100;
    private bool canTakeDamage = true;
    private bool isAttacking = false;
    EnemyDistance enemyDistance;
    EnemyMelee enemyMelee;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Normal;
        rb = player.GetComponent<Rigidbody2D>();
        inventory.enabled = false;
        anim = player.GetComponent<Animator>();

        anim.SetBool("attack",false);
        anim.SetBool("roll",false);

        enemyDistance = FindObjectOfType<EnemyDistance>();
        enemyMelee = FindObjectOfType<EnemyMelee>();
    }
    private enum State
    {
        Normal,
        DodgeRollState,
    }
    // Update is called once per frame
    void Update()
    {

        switch (state) {
            case State.Normal:

        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        if(Input.GetKey(KeyCode.D) && isAttacking == false)
                {
                    anim.SetBool("running", true);
                    anim.SetBool("roll", false);
                    anim.SetBool("attack", false);
                    player.GetComponent<SpriteRenderer>().flipX = false;
                }
        
        else
                {
                    anim.SetBool("running", false);
                }
        if (Input.GetKey(KeyCode.A) && isAttacking == false)
                {
                    anim.SetBool("running", true);
                    anim.SetBool("roll", false);
                    anim.SetBool("attack", false);
                    player.GetComponent<SpriteRenderer>().flipX = true;
                }
                if (Input.GetKey(KeyCode.S) && isAttacking == false)
                {
                    anim.SetBool("running", true);
                    anim.SetBool("roll", false);
                    anim.SetBool("attack", false);
                }
                if (Input.GetKey(KeyCode.W) && isAttacking == false)
                {
                    anim.SetBool("running", true);
                    anim.SetBool("roll", false);
                    anim.SetBool("attack", false);
                }

                if (nextRollTime < Time.time) {
                    ManageRoll();
                    nextRollTime = Time.time + rollRate;
                }
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
                    anim.SetBool("running", false);
                    anim.SetBool("roll", false);
                    anim.SetBool("attack", true);
                    isAttacking = true;
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

               
                    Roll();
                 
        break;
    }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * velocity * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "EnemyDistance" && isAttacking == true)
        {
            enemyDistance.TakeDamage(15);
        }
        if(collision.transform.tag == "EnemyMelee" && isAttacking == true)
        {
            enemyMelee.TakeDamage(10);
        }
        if(collision.transform.tag == "SpecialEnemy" && isAttacking == true)
        {

        }
    }
    private void ManageRoll()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("roll", true);
            anim.SetBool("running", false);
            anim.SetBool("attack", false);

            
            rollDirection = new Vector3(direction.x, direction.y, 0);
            rollVelocity = 100f;
            state = State.DodgeRollState;

        }
    }
    public void Attack()
    {
        
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
            lifesPlayer -= quantity;
        }
        if (lifesPlayer <= 0)
        {

        }
    }
    
    private void Run()
    {
        velocity += 2f;
        isRunning = true;
    }
}

