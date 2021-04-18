using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public string name="Sensei";

    [TextArea(3, 10)]
    [SerializeField] public string[] sentenceList;
}

