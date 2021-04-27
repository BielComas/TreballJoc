using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject canvas;


    [SerializeField] Queue<string> sentences;


    public void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialog dialogue)
    {
        Time.timeScale = 0f;

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentenceList)
        {
            sentences.Enqueue(sentence);
        }
    }
    public void ShowNextSentence()
    {
        if (sentences.Count <= 0)
        {
            canvas.SetActive(false);
            Time.timeScale = 1f;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        Time.timeScale = 0f;
    }

}
