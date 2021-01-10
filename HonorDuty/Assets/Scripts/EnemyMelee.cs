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
    public EnemyState currentState;
    public int health;
    public int baseAttack;
    public float moveSpeed;

    public Transform target;

    public float chaseRadius;
    public float attackRadius;
    private Transform homePosition;

    public Animator animator;
    public Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }
    public virtual void CheckDistance()
    {
        if (Vector3.Distance(target.position,
            transform.position) <= chaseRadius
            && Vector3.Distance(target.position,
            transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position,
                    target.position, moveSpeed * Time.deltaTime);

                myRigidBody.MovePosition(temp);
                changeAnim(temp - transform.position);
                ChangeState(EnemyState.walk);
                animator.SetBool("WakeUp", true); ;
            }
            else if (Vector3.Distance(target.position,
            transform.position) > chaseRadius)
            {
                animator.SetBool("WakeUp", false);
            }
        }
    }
    public void SetAnimFloat(Vector2 setVector)
    {
        animator.SetFloat("MoveX", setVector.x);
        animator.SetFloat("MoveY", setVector.y);

    }
    public void changeAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }
            else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }
    }
    public void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
}
