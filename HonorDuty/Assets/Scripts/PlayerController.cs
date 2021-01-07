using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector2 direction;
    public float velocity = 3f;
    public float rollVelocity = 300f;
    public float nextRollTime;
    private bool isRunning = false;
    private bool canRoll = true;
    public float rollRate = 10f;
    Rigidbody2D rb;
    [SerializeField] int lifesPlayer = 100;
    private bool canTakeDamage = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && canRoll == true)
        {
            if (nextRollTime < Time.time)
            {
                
                Roll();
                nextRollTime = Time.time + rollRate;
            }
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

    }
    public void TakeDamage()
    {
        if(canTakeDamage == true)
        {
            lifesPlayer -= 1;
        }
        if (lifesPlayer <= 0)
        {

        }

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * velocity * Time.deltaTime);
    }
    private void Roll()
    {       
        canRoll = true;
    }
    private void Run()
    {
        velocity += 2f;
        isRunning = true;
    }
}
