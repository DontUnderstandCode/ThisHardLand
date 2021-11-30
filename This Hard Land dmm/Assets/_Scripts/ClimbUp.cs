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
    bool doClimb;


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

    private void OnTriggerExit()
    {
        pmManage.shouldClimb = false;
        pmManage.doClimb = false;
        charAnim.SetTrigger("jump2Top1");
    }

    void PLRStartClimb()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            lrMove.enabled = false;
            charAnim.SetTrigger("climbTurn1");  
        }
    }

    void PLRClimb()         //Checks whether the player should be climbing and if so, moves them into the correct position in time with the character animation and then moves them up.
    {
       

        if(doClimb)
        {
        
        
          
            player.transform.Translate(0, 1f * Time.deltaTime, 0);     
        

                       
        }
        
    }



    // Update is called once per frame
    void Update()
    {
        shouldClimb = pmManage.shouldClimb;
        doClimb = pmManage.doClimb;


        
        if(shouldClimb)
        {
            if(doClimb)
            {
                PLRClimb();
            }
            else if(!doClimb)
            {
                PLRStartClimb();
            }
         
            

        }
        




        
    }
}
