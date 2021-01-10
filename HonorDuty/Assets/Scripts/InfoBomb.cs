using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoBomb : MonoBehaviour
{
    [SerializeField] public Text info;
    infoShuriken shuriken;
    private void Start()
    {
        
      
        info.enabled = false;
        
    }

    public void ShowInfo()
    {
        shuriken.enabled = false;
        info.enabled = true;
    }
}
