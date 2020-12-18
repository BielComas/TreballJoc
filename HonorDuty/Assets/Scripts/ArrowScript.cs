using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    [SerializeField] Transform arrow;
    float velocity = 4f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        arrow.position = new Vector2(arrow.position.x + 1 * velocity * Time.deltaTime,arrow.position.y * velocity * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {

        }
    }
}
