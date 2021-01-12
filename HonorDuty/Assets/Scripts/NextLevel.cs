using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextLevel : MonoBehaviour
{

    private Collider2D collision;
    public ManagerLevel managementLevel;

    public void Start()
    {
        //Fem referencia al collider en la variable col·lisió.
        collision = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Quan toquem el trigger es quan salta el gestor de nivells
        //i cada cop que toquem un trigger passará al següent nivell.
        managementLevel.LoadNextLevel();
    }



}
