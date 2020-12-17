using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector2 direction;
    public float velocity = 4f;
    Rigidbody2D rb;
    [SerializeField] int lifesPlayer = 100;
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

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * velocity * Time.deltaTime);
    }
}
