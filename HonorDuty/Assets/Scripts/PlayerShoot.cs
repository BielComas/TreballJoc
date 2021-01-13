using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject shuriken;
    [SerializeField] Transform firePoint;
    public Vector2 mousePos;
    public Camera cam;
    float nextFireTime = 0f;
    float fireRate = 3f;

    // Update is called once per frame
    void Update()
    {

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (nextFireTime < Time.time)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }
            
        
    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(shuriken, firePoint.position, shuriken.transform.rotation);
        Rigidbody2D rb2 = bullet.GetComponent<Rigidbody2D>();
        rb2.velocity = new Vector2(mousePos.x - firePoint.position.x, mousePos.y - firePoint.position.y);
    }
}
