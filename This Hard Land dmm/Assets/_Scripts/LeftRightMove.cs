using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMove : MonoBehaviour
{
    GameObject gameManager;
    PlayerManager pmManage;

    private float distance;
    private float playerZ1;
    private float playerZ2;   //These three flaots are used to work out the horizontal distance teh player  has moved, which will be then used to work out the appropriate speed
    
    
    private float speed;   //This will hold the speed value of the player and will be set according to an exponential function and the players position

    bool posMinus;  //This is just the x value of the player transform to check what side of the board they are on

    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();
        speed = 0;
        distance = 0;
    }

    void MovePlayer()
    {
        transform.Translate(0, 0, speed);      //This is the method that moves the player according to the speed decided in the following functions
    }


    void SpeedSetA()
    {
        
        posMinus = pmManage.posMinus;
        pmManage.isRunningLeft = true;
        
        if(posMinus)
        {
            speed = -1 * speed; 
        }
        else if(!posMinus)
        {
            speed = speed; 
        }
    }

        void SpeedSetD()
    {
        posMinus = pmManage.posMinus;
        pmManage.isRunningRight = true;

        if(posMinus)
        {
            speed = speed; 
        }
        else if(!posMinus)
        {
            speed = -1 * speed;   //Both speedset functions check which side of the puzzle the player is on and set the speed accordingly. Basically it reverses the movement speed on the "negative" side of the board
        }
    }

    void DistanceMeasure()              //A method that measures how far the player has travelled in the Z direction in any one movement cycle. Uses as the input for the Exponential equation that defines player speed.
    {
        distance = distance + (playerZ2 - playerZ1);
        SpeedCalculate();                              //The next function to calculate the proper speed is then called
    }

    void SpeedCalculate()                     //A method that uses an exponential functin to work out how fast the player should be going. This enforces a short acceleration period that looks better
    {   
        float distZ = (distance * distance);       //The distance calculated in the previous method can be negative or positive so this must be made positive in all cases before it's used
        distZ = Mathf.Sqrt(distZ);
        speed = (-2.8f) * Mathf.Pow(9, (-2 * distZ)) +3;            //This is the actual function, setting a speped that increases rapidly from 0 to a max of 3.
        speed = speed * Time.deltaTime;
    }



    // Update is called once per frame
    void Update()
    {   playerZ1 = pmManage.playerCoord.z;    //Gets a first reading of player coordinate to be used to calculate z distance travelled
        

        if(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            DistanceMeasure();
            SpeedSetA();
            MovePlayer();
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))   //Checks whether the left or right button is pressed and uses the logic in the "speedset" methods to decide which way to go
        {                                                               //The extra condition is used to make the system more robust and stop you form running th ewrong way
            DistanceMeasure();    
            SpeedSetD();
            MovePlayer();
        }
        else
        {
            pmManage.isRunningLeft = false;
            pmManage.isRunningRight = false;
            distance = 0;
        }
    }

    void LateUpdate()
    {
        playerZ2 = pmManage.playerCoord.z;   //Gets a second reading of player z later in the frame to be used to calculate z distance travelled
    }
}
