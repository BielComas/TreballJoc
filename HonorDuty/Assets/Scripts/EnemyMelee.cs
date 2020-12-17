using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee: MonoBehaviour
{
    public Transform target;
    public float speed = 10f;
    Vector3 InitialPosition;
    public float RatioVision;
    public float RatioAttack;
    Rigidbody2D rb2d;
    GameObject Player;

    //In the method start the enemy detect PlayerController.
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
    }


   public void Update()
    {
        Vector3 targetPlayer = InitialPosition;

        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            Player.transform.position - transform.position,
            RatioVision,
            1<< LayerMask.NameToLayer("Default")
            //here what we do is put it in another layer to avoid RayCast.
            );

        Vector3 forward = transform.TransformDirection(Player.transform.position - transform.position);
        Debug.DrawLine(transform.position, forward, Color.red);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player")
            {
                targetPlayer = Player.transform.position;
            }
        }

        float distance = Vector3.Distance(targetPlayer, transform.position);
        Vector3 dir = (targetPlayer - transform.position).normalized;

        if (targetPlayer != InitialPosition && distance < RatioAttack)
        {
            //AnimationEnemy.x
            //AnimatioEnemy.y
            //AnimatioCaminar
            //QuitarVida
        }
        else
        {
            rb2d.MovePosition(transform.position + dir * speed * Time.deltaTime);
        }

    }


    public void FixedUpdate()
    {
        
    }
}
