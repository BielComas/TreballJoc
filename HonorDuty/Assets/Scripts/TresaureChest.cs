using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TresaureChest : MonoBehaviour
{
    Animator anim;
    private bool CanOpen = false;
    [SerializeField] GameObject Summon1, Summon2;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
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
        }
    }
    private void GenerateSummon()
    {
        anim.SetBool("open", false);
    }
    

}
