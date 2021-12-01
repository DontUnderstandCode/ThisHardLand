using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbUp : MonoBehaviour     //This script checks whether the player is within the "climb" collider and sets in motion the animations and methods to make the player climb a level
{                                        //The collider must be positioned so that it's origin is in line vertically with the climb area of the map
                                         //The collider is intended to be used as a  prefab that we can place wherever we want the player to climb and it will work automatically.
    GameObject gameManager;
    PlayerManager pmManage;
 

/////////////////////////////////
    GameObject player;
    LeftRightMove lrMove;
//////////////////////////////////////
    GameObject charModel;
    Animator charAnim;
    /////////////////////////////// _ This section is for the variables that help in aligning the player to the climb object.

    bool shouldClimb = false;
    bool doClimbUp;

    float colldrY;        //Used to tell the player object to stop moving up.
    float plrY;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        lrMove = player.GetComponent<LeftRightMove>();


        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();

        charModel = GameObject.Find("Lost John");
        charAnim = charModel.GetComponent<Animator>();

        
    }

    private void OnTriggerEnter(Collider climbUp)         //Thisis the bit that sets the climb sequence in motion  //OnTrigger enter climbable
    {
        if (climbUp.gameObject.name == "Player")
        {
            pmManage.shouldClimb = true;
        }
    }

    private void OnTriggerExit(Collider climbUpOut)
    {
        pmManage.shouldClimb = false;
    }



    void PLRStartClimb()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            lrMove.enabled = false;
            charAnim.SetTrigger("climbTurn1");
            colldrY = transform.position.y;
        }
    }

    void PLRClimb()         //Checks whether the player should be climbing and if so, moves them into the correct position in time with the character animation and then moves them up.
    {
     
        plrY = player.transform.position.y;
        if(plrY  < colldrY)
        {
            player.transform.Translate(0, 1f * Time.deltaTime, 0);
        }
        else if(plrY > colldrY)
        {
            pmManage.shouldClimb = false;
            pmManage.doClimbUp = false;
            charAnim.SetTrigger("jump2Top1");
        }  
    }



    // Update is called once per frame
    void Update()
    {
        shouldClimb = pmManage.shouldClimb;
        doClimbUp = pmManage.doClimbUp;



        if (shouldClimb)
        {


            PLRStartClimb();

        }
        if(doClimbUp)
        {
                PLRClimb();
        }


        
    }
}
