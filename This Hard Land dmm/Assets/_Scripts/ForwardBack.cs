using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardBack : MonoBehaviour
{
   private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
    }

    void MoveForward()
    {
        transform.Translate(speed, 0, 0);
    }

    void MoveBack()
    {
        transform.Translate(speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            speed = -5 * Time.deltaTime;
            MoveForward();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            speed = 5 * Time.deltaTime;
            MoveBack();
        }
    }
}
