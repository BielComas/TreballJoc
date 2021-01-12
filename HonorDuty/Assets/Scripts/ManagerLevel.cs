using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerLevel : MonoBehaviour
{
    int actualScene;
    int nextEscene;

    public void LoadNextLevel()
    {
        //El build index lo que fa es agafar el numero del build d'escenes i comptarles.
        actualScene = SceneManager.GetActiveScene().buildIndex;
        //Quan canvii d'escena passará a estar en l'escena ex(0 passará a escena 1 gràcies al ++).
        nextEscene = actualScene++;
        //Llavors s'executará l'escena.
        SceneManager.LoadScene(actualScene);

    }
}
