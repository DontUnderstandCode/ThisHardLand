using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMove : MonoBehaviour //This script calculates how far the player has moved in any given cycle, calculates a speed using an exponential function, and then moves the player accordingly
{                                          //The exp function is used to give a nicer feel and make him look more natural as he turns
    GameObject gameManager;
    PlayerManager pmManage;

    

    private float playerZ1;
    private float playerZ2;   //These three flaots are used to work out the horizontal distance teh player  has moved, which will be then used to work out the appropriate speed
    public float distance;
    public float distZ;


    private float speed;   //This will hold the speed value of the player and will be set according to an exponential function and the players position
    private float setSpeed;

    bool posMinus;  //This is just the x value of the player transform to check what side of the board they are on

    bool left;
    bool right;



    ///////////////////////////////////////////////////////////////////////////

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();
        speed = 0;
        distance = 0;
    }

    ///////////////////////////////////////////////////////////////////////////

    void MovePlayer()
    {
        transform.Translate(0, 0, setSpeed);      //This is the method that moves the player according to the speed decided in the following functions
    }


    void SpeedSetA()
    {
        
        posMinus = pmManage.posMinus;
  

        if (posMinus)
        {
            setSpeed = -1 * speed; 
        }
        else if(!posMinus)
        {
            setSpeed = speed; 
        }
    }

    void SpeedSetD()
    {
        posMinus = pmManage.posMinus;
  

        if (posMinus)
        {
            setSpeed = speed; 
        }
        else if(!posMinus)
        {
            setSpeed = -1 * speed;   //Both speedset functions check which side of the puzzle the player is on and set the speed accordingly. Basically it reverses the movement speed on the "negative" side of the board
        }
    }

    void DistanceMeasure()              //A method that measures how far the player has travelled in the Z direction in any one movement cycle. Used as the input for the Exponential equation that defines player speed.
    {
        distance = distance + (playerZ2 - playerZ1);      
        SpeedCalculate();                              //The next function to calculate the proper speed is then called
    }

    void SpeedCalculate()                     //A method that uses an exponential functin to work out how fast the player should be going. This enforces a short acceleration period that looks better
    {

        distZ = (distance * distance);       //The distance calculated in the previous method can be negative or positive but this must be made positive in all cases before it's used so corrected here
        distZ = Mathf.Sqrt(distZ);
        speed = (-2.9f) * Mathf.Pow(8, (-2 * distZ)) +3;            //This is the actual function, setting a speed that increases rapidly from just above zero to a max of 3.
        speed = speed * Time.deltaTime;                             //the actual start speed
    }



    ///////////////////////////////////////////////////////////////////////////////////////////////////////

    void Update()
    {   playerZ1 = pmManage.playerCoord.z;    //Gets a first reading of player coordinate to be used to calculate z distance travelled
        
   

        if(Input.GetKeyDown(KeyCode.A) )       //When the left key is pressed, switches the bool to say it running left and not right, also resets the distance measurements to 0
        {                                     
            pmManage.isRunningLeft = true;     //Uses the Player Manager variable so that it can be influenced frmo other scripts when required.
            pmManage.isRunningRight = false;
            distance = 0;
            distZ = 0;
        }
        if (Input.GetKeyUp(KeyCode.A))        //When the left key is relseased, says that hes no longer running left, but could be running right
        {
            pmManage.isRunningLeft = false;
        }
        if (pmManage.isRunningLeft)          //If he is running left, perform the distance calculations above which dictate how fast hes going
        {                                    //Also runs a "left" specific method to set the speed depending on what side of the board hes on.
            DistanceMeasure();
            SpeedSetA();
            MovePlayer();
        }

        /////////////////////////////////////////////////////////////////////////////////
        
        if (Input.GetKeyDown(KeyCode.D))       //this block is just the revers of what's above
        {                                                           
            pmManage.isRunningRight = true;
            pmManage.isRunningLeft = false;
            distance = 0;
            distZ = 0;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            pmManage.isRunningRight = false;
        }
        if (pmManage.isRunningRight)
        {
             DistanceMeasure();
             SpeedSetD();
             MovePlayer();
        }
    
        /////////////////////////////////////////////////////////////////////////////////////
        
        else if(!pmManage.isRunningRight && !pmManage.isRunningLeft)     //Says tha tif he's not runnning either direction then rest distances to 0
        {
            distance = 0;
            distZ = 0;
        }
    }

    void LateUpdate()
    {
        playerZ2 = pmManage.playerCoord.z;   //Gets a second reading of player z later in the frame to be used to calculate z distance travelled
    }
}
