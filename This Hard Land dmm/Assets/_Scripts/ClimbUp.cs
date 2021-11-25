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
//////////////////////////////////////
    GameObject charModel;
    Animator charAnim;
/////////////////////////////// _ This section is for the variables that help in aligning the player to the climb object.

    bool shouldClimb = false;

    



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();

        charModel = GameObject.Find("Lost John");
        charAnim = charModel.GetComponent<Animator>();


    }

    private void OnTriggerStay(Collider climbUp)         //Thisis the bit that sets the climb sequence in motion
    {
        if (climbUp.gameObject.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))                //When E is pressed
            {
                charAnim.SetTrigger("climbTurn1");          //Start teh character model animations equence
            } 
            
           
            PLRClimb();           //While within the colider check if supposed to be aligning and if so do
        }
    }



    void PLRClimb()         //Checks whether the player should be climbing and if so, moves them into the correct position in time with the character animation and then moves them up.
    {
        Vector3 colldrCoord = transform.position;
        Vector3 playerCoord = pmManage.playerCoord;
        float playerZ = playerCoord.z;
        float colldrZ = colldrCoord.z;
        float diffZ = colldrZ - playerZ;

        if(shouldClimb)
        {
            if(diffZ != 0)
            {
                player.transform.position = Vector3.MoveTowards(playerCoord, colldrCoord, 0.05f);   //Thanks to AlexKelly on unity answers for posting this MoveToward function as an asnswer
            }

            else if(diffZ == 0)
            {
                player.transform.Translate(0, 1f * Time.deltaTime, 0);     
            }

                       
        }
        
    }



    // Update is called once per frame
    void Update()
    {
        shouldClimb = pmManage.shouldClimb;




        
    }
}
