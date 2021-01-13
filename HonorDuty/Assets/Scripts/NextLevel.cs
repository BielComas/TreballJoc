using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextLevel : MonoBehaviour
{

    PlayerController player;
    ManagerLevel managementLevel;

    public void Start()
    {
        player = FindObjectOfType<PlayerController>();
        managementLevel = FindObjectOfType<ManagerLevel>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == player.name)
        {
            managementLevel.LoadNextLevel();
        }
    }



}
