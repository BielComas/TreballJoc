using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee
   : MonoBehaviour
{
    private Transform target;
    private float speed;

    //In the method start the enemy detect PlayerController.
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
    }


    void Update()
    {
        FollowPlayer();
    }

    //This method the enemy follow the player.
    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
