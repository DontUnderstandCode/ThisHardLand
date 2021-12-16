using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbUpB : MonoBehaviour
{
    GameObject gameManager;
    PlayerManager pmManage;
    ///////////////////////////////////////
    GameObject pgParent;                                     //Refers to the top level player object
    ForwardBack forwardBack;                                 //The script that moves the player between levels, will be disabled while climbing
 

/////////////////////////////////
    GameObject player;
    LeftRightMove lrMove;
//////////////////////////////////////
    GameObject charModel;
    Animator charAnim;
    /////////////////////////////// _ This section is for the variables that help in aligning the player to the climb object.

    bool shouldClimb = false;    //This is switched when the player is within the climbable area
    bool startClimb;             //This is switched when the player presses climb, and allows the climb sequence to start if the player is in the climbable area
    bool doClimbUp;             // This is switched when the player completes the first part of the climbing sequenec and is supposed to start moving up
 
    float colldrY;        //Used to tell the player object to stop moving up.
    float plrY;          //When one supersedes the other, the player has climbed the corr3ect height


    // Start is called before the first frame update
    void Start()
    {
        pgParent = GameObject.Find("PlayerGlobalParent");
        forwardBack = pgParent.GetComponent<ForwardBack>();

        player = GameObject.Find("Player");
        lrMove = player.GetComponent<LeftRightMove>();      //LeftRight script 


        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>(); //The player manager which is important here because it holds the "doClimb" bool triggered by an animation event

        charModel = GameObject.Find("Lost John");
        charAnim = charModel.GetComponent<Animator>();         //Refers to character model for animations
    }

    private void OnTriggerEnter(Collider climbUp)         //This determines whether the player is in the climbable area
    {
        if (climbUp.gameObject.name == "Player")       
        {
            shouldClimb = true;                         
        }
    }

    private void OnTriggerExit(Collider climbUpOut)       //Same as above
    {
        if(climbUpOut.gameObject.name == "Player")
        {
            shouldClimb = false;           
        }
        
    }



    void PLRStartClimb()        //Triggered when the player presses climb
    {
        if(shouldClimb)
        {
            startClimb = true;               //says the player could potentially climb
            lrMove.enabled = false;                 //Stops teh player moving left or right
            //forwardBack.enabled = false;            //Stops the player moving forwards or backwards
            pmManage.canFordsBack = false;          //Tells the player manager script that it cant go forwards or backwards
            charAnim.SetTrigger("climbTurnB");      //Starts the first animation in the climbing sequence
            colldrY = transform.position.y;         //Checks the location of the transform of the shader, important so the player knows when to stop climbing
        }
    }

    void PLRClimb()         //Checks whether the player should be climbing and if so, moves them into the correct position in time with the character animation and then moves them up.
    {
        plrY = player.transform.position.y;            //checks every frame the height of the player
        if(plrY  < colldrY)
        {
            player.transform.Translate(0, 1f * Time.deltaTime, 0);   //If the player has not yet reached the correct height, add height
        }
        else if(plrY > colldrY)
        {
            startClimb = false;
            pmManage.doClimbUp = false;
            charAnim.SetTrigger("jump2TopB"); //If the player has, stop the player from climbing, and trigge the end animatin of the sequence
        }  
    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            PLRStartClimb();                    //When space is pressed start the check and if successful, the sequence
        }

        doClimbUp = pmManage.doClimbUp;      //Take the glovbally common value, to check if it should climb, triggered by an animation event
        
        if (startClimb)                //The reason for using two bools here is because "doClimbUp" is triggered glboally, and We only want this particular "cllimbUp" script to run.
        {                              // Without this step, they all run at once and its mental. Basically it shields the PLRClimb functin from the global variable byad ding an extra step
            if(doClimbUp)
            {
                PLRClimb();     //if all checks successful then do the climb
            }

                

        }
    }
}
