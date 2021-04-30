using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Dialog dialogue;
    public GameObject DialogueStart;

    // Start is called before the first frame update
   public void Start()
    {
        canvas.GetComponent<Canvas>().enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            canvas.GetComponent<Canvas>().enabled = true;
            FindObjectOfType<DialogManager>().StartDialogue(dialogue);
            Time.timeScale = 0f;
            GameObject.Destroy(DialogueStart);

            if (DialogueStart == null)
            {
              Time.timeScale = 1f;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        canvas.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1f;
    }
}
