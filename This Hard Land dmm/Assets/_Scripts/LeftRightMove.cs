using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMove : MonoBehaviour
{
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
    }

    void MoveLeft()
    {
        transform.Translate(0, 0, speed);
    }

    void MoveRight()
    {
        transform.Translate(0, 0, speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            speed = -5 * Time.deltaTime;
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speed = 5 * Time.deltaTime;
            MoveRight();
        }

        


    
    }
}
