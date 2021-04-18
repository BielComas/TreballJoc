using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] public string name;

    [TextArea(3, 10)]
    [SerializeField] public string[] sentenceList;
}

