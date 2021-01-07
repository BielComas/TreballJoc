using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector2 direction;
    public float velocity = 3f;
    private bool isRunning = false;
    Rigidbody2D rb;
    private State state;
    private Vector3 rollDirection;
    [SerializeField] int lifesPlayer = 100;
    private bool canTakeDamage = true;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Normal;
        rb = player.GetComponent<Rigidbody2D>();
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
                break;
            case State.DodgeRollState:
                Roll();
                break;
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
    private void ManageRoll()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            state = State.DodgeRollState;
            rollDirection = new Vector3(direction.x, direction.y, 0);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            state = State.Normal;
        }
    }
    private void Roll()
    {
        float rollVelocity = 2f;
        player.position += rollDirection * rollVelocity * Time.deltaTime;
    }
    private void Run()
    {
        velocity += 2f;
        isRunning = true;
    }
}
