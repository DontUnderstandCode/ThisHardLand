using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapMove : MonoBehaviour
{
    float playerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 0;
    }

    void GoRight()
    {
        transform.Translate(-8 *Time.deltaTime, 0, 0);
    }

    
    void GoLeft()
    {
        transform.Translate(8 *Time.deltaTime, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            GoRight();
        }
        else if(Input.GetKey(KeyCode.A))
        {
            GoLeft();
        }
    }
}
