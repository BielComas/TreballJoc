using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBomb : MonoBehaviour
{
    private Vector3 targetPos;

    public GameObject smoke;
    public float speed = 5;
    public float playerHiden;
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (speed > 0)
        {
            speed -= Random.Range(.1f, .40f);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
        else if (speed < 0)
        {
            speed = 0;
            StartCoroutine(Explode(1));
        }
    }
    IEnumerator Explode(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(smoke, transform.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("Smoke Bomb");
        Destroy(gameObject);
    }
}
