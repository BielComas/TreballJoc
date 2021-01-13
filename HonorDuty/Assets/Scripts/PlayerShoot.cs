using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] ShurikenScript shuriken;
    public Vector2 mousePos;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
       
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
           //Instanciar
        }
    }
}
