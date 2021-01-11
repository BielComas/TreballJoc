using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public float damage = 1f;
    public Rigidbody2D rb2d;

    //If the sword collision with enemy, enemy die
    public void OnTriggerEnter2D(Collider2D other)
    {
       if (Input.GetKeyDown("Button0"))
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                //if live enemy arrives 0
                Destroy(this.gameObject);

            }
        }
        


    }
}
