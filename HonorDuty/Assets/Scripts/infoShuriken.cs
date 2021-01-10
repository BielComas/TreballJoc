using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoShuriken : MonoBehaviour
{
    [SerializeField] public Text info;
    InfoBomb infobomb;
    private void Start()
    {
        info = GetComponent<Text>();
        infobomb = FindObjectOfType<InfoBomb>();
        info.enabled = false;
        
    }

    public void ShowInfo()
    {
        infobomb.enabled = false;
        info.enabled = true;
    }
}

