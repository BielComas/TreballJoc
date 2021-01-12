using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Level2"))
        {
            NextLevel2();
        }
    }

    //Escena nivell 2.
    public void NextLevel2()
     {
     SceneManager.LoadScene("level2");
     }

    //Escena nivell 3.
    public void NextLevel3()
    {
        SceneManager.LoadScene("level3");
    }

    //Escena nivell 4.
    public void NextLevel4()
    {
        SceneManager.LoadScene("level4");
    }
    

}
