using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMove : MonoBehaviour
{
    GameObject gameManager;
    PlayerManager pmManage;
    private float speed;   //This will hold the speed value of the player and will be set according to position and key

    bool posMinus;  //This is just the x value of the player transform to check what side of the board they are on

    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();
        speed = 0;
    }

    void MovePlayer()
    {
        transform.Translate(0, 0, speed);      //This is the method that moves the player according to the speed decided in the following functions
    }


    void SpeedSetA()
    {
        posMinus = pmManage.posMinus;
        if(posMinus)
        {
            speed = -5 * Time.deltaTime;
        }
        else if(!posMinus)
        {
            speed = 5 * Time.deltaTime;
        }
    }

        void SpeedSetD()
    {
        posMinus = pmManage.posMinus;
        if(posMinus)
        {
            speed = 5 * Time.deltaTime;
        }
        else if(!posMinus)
        {
            speed = -5 * Time.deltaTime;    //Both speedset functions check which side of the puzzle the player is on and set the speed accordingly. Basically it reverses the movement speed on the "negative" side of the board
        }
    }



    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetKey(KeyCode.A))
        {
            SpeedSetA();
            MovePlayer();
        }
        else if (Input.GetKey(KeyCode.D))   //Checks whether the left or right button is pressed and uses the logic in the "speedset" methods to decide which way to go
        {
            SpeedSetD();
            MovePlayer();
        }

        


    
    }
}
