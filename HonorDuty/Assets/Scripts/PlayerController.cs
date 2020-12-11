using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 direction;
    [SerializeField] int lifesPlayer = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horitzontal");
        direction.y = Input.GetAxis("Vertical");

    }
}
