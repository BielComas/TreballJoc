using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeArea : MonoBehaviour
{
    public float radius = 2;
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        StartCoroutine(Desapear());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position, radius);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            player.isHiden = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.transform.tag == "Player")
        {
            player.isHiden = false;
        }
    }
    IEnumerator Desapear()
    {
        yield return new WaitForSeconds(6f);
        Destroy(gameObject);
    }
}
