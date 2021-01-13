using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerLevel : MonoBehaviour
{
    

    public void LoadNextLevel()
    {
        int actualScene;
        int nextEscene;
        //El build index lo que fa es agafar el numero del build d'escenes i comptarles.
        actualScene = SceneManager.GetActiveScene().buildIndex;
        //Quan canvii d'escena passará a estar en l'escena ex(0 passará a escena 1 gràcies al ++).
        nextEscene = actualScene + 1;
        //Llavors s'executará l'escena.
        SceneManager.LoadScene(nextEscene);

    }

    public void DefeatLevel()
    {
        SceneManager.LoadScene("Defeat");
    }
    public void loadMain()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadWin()
    {
        SceneManager.LoadScene("Win");
    }
   
}
