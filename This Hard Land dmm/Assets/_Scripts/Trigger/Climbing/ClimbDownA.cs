using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbDownA : MonoBehaviour
{
    GameObject gameManager;
    PlayerManager pmManage;
/////////////////////////////////////
    GameObject pgParent;                                     //Refers to the top level player object
    ForwardBack forwardBack;                                 //The script that moves the player between levels, will be disabled while climbing
    /////////////////////////////////
    GameObject player;
    LeftRightMove lrMove;
    //////////////////////////////////////
    GameObject charModel;
    Animator charAnim;
    /////////////////////////////// _ This section is for the variables that help in aligning the player to the climb object.
    
    bool shouldClimbDown = false;
    bool startClimbDown;
    bool doClimbDown;

    float colldrY;        //Used to tell the player object to stop moving up.
    float plrY;

    /////////////////////////////////////////////////////
    
    // Start is called before the first frame update
    void Start()
    {
        pgParent = GameObject.Find("PlayerGlobalParent");
        forwardBack = pgParent.GetComponent<ForwardBack>();

        player = GameObject.Find("Player");
        lrMove = player.GetComponent<LeftRightMove>();


        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();

        charModel = GameObject.Find("Lost John");
        charAnim = charModel.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider climbDown)         //Thisis the bit that sets the climb sequence in motion  //OnTrigger enter climbable
    {
        if (climbDown.gameObject.name == "Player")
        {
            shouldClimbDown = true;
        }
    }

    private void OnTriggerExit(Collider climbDownOut)
    {
        if(climbDownOut.gameObject.name == "Player")
        {
            shouldClimbDown = false;
        }
        
    }


    void PLRStartClimbDown()
    {
        if (shouldClimbDown)
        {
            startClimbDown = true;
            lrMove.enabled = false;
            forwardBack.enabled = false;            //Stops the player moving forwards or backwards
            charAnim.SetTrigger("climbDownTurnA");
            colldrY = transform.position.y;

        }
    }

    void PLRClimbDown()         //Checks whether the player should be climbing and if so, moves them into the correct position in time with the character animation and then moves them up.
    {
        plrY = player.transform.position.y;
        if (plrY > colldrY)
        {
            player.transform.Translate(0, -1f * Time.deltaTime, 0);
        }
        else if (plrY < colldrY)
        {
            startClimbDown = false;
            pmManage.doClimbDown = false;
            charAnim.SetTrigger("jump2BaseA");
        }
    }



    // Update is called once per frame
    void Update()
    {
           if(Input.GetKeyDown(KeyCode.Space))
        {
            PLRStartClimbDown();                    //When space is pressed start the check and if successful, the sequence
        }
        doClimbDown = pmManage.doClimbDown;



        if (startClimbDown)
        {
            if (doClimbDown)
            {
                PLRClimbDown();
            }

        }
    }
}
