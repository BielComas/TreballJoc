using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    [SerializeField] GameObject shuriken;
    [SerializeField] Transform firePoint;
    public Vector2 mousePos;
    public Camera cam;
    float nextFireTime = 0f;
    float fireRate = 3f;
    public int numShurikens = 0;
    public int numBombs = 0;

    // Update is called once per frame
    void Update()
    {

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (numShurikens > 0)
            {

                if (nextFireTime < Time.time)
                {
                    ShootShuriken();
                    nextFireTime = Time.time + fireRate;
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (numBombs > 0)
            {
                if (nextFireTime < Time.time)
                {
                    ShootBomb();
                    nextFireTime = Time.time + fireRate;
                }
            }


        }
    }
    public void ShootShuriken()
    {
        GameObject bullet = Instantiate(shuriken, firePoint.position, shuriken.transform.rotation);
        Rigidbody2D rb2 = bullet.GetComponent<Rigidbody2D>();
        rb2.velocity = new Vector2(mousePos.x - firePoint.position.x, mousePos.y - firePoint.position.y);
    }
    public void ShootBomb()
    {
        Instantiate(bomb, firePoint.position, bomb.transform.rotation);
       
    }
}
