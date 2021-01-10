using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TresaureChest : MonoBehaviour
{
    Animator anim;
    private bool CanOpen = false;
    [SerializeField] GameObject Summon1, Summon2;
    private int random;
    [SerializeField] Canvas pressE;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        pressE.enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CanOpen == true)
        {
            anim.SetBool("open", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            CanOpen = true;
            pressE.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        pressE.enabled = false;
    }
    private void GenerateSummon()
    {
        anim.SetBool("open", false);
        random = Random.Range(1, 3);


        if(random == 1)
        {
            Instantiate(Summon1,gameObject.transform);
            print("si");
        }
        if(random == 2)
        {
            Instantiate(Summon2, gameObject.transform);
            print("no");
        }
    }
    

}
