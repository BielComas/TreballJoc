using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Dialog dialogue;
    // Start is called before the first frame update
    void Start()
    {
        canvas.GetComponent<Canvas>().enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            canvas.GetComponent<Canvas>().enabled = true;
            FindObjectOfType<DialogManager>().StartDialogue(dialogue);
        }
    }
}
