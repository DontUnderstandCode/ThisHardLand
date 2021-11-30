using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbDown : MonoBehaviour
{
    GameObject gameManager;
    PlayerManager pmManage;


    /////////////////////////////////
    GameObject player;
    LeftRightMove lrMove;
    //////////////////////////////////////
    GameObject charModel;
    Animator charAnim;
    /////////////////////////////// _ This section is for the variables that help in aligning the player to the climb object.

    bool shouldClimbDown = false;
    bool doClimbDown;


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

    private void OnTriggerEnter(Collider climbDown)         //Thisis the bit that sets the climb sequence in motion  //OnTrigger enter climbable
    {
        if (climbDown.gameObject.name == "Player")
        {
            pmManage.shouldClimbDown = true;
        }
    }

    private void OnTriggerExit()
    {
        pmManage.shouldClimbDown = false;
        pmManage.doClimbDown = false;
        charAnim.SetTrigger("jump2Base1");
    }

    void PLRStartClimbDown()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            lrMove.enabled = false;
            charAnim.SetTrigger("climbDownTurn1");
        }
    }

    void PLRClimbDown()         //Checks whether the player should be climbing and if so, moves them into the correct position in time with the character animation and then moves them up.
    {

            player.transform.Translate(0, 1f * Time.deltaTime, 0);
    }



    // Update is called once per frame
    void Update()
    {
        shouldClimbDown = pmManage.shouldClimbDown;
        doClimbDown = pmManage.doClimbDown;



        if (shouldClimbDown)
        {
            if (doClimbDown)
            {
                PLRClimbDown();
            }
            else if (!doClimbDown)
            {
                PLRStartClimbDown();
            }



        }






    }
}
