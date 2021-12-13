using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardBack : MonoBehaviour   //This script organises and starts the animation that moves the player from one side of the board to another 
{                                          //It is attatched to the Top level player parent to allow it to move forward and backward without having to
                                           //Worry about the players position in-plane. The ppurpose of this object is just to move forwards and backwards.

    Animator globalAnim;                   //The aniamtor attatched to this object

    GameObject johnChild; 
    Animator charAnim;                    //The player character model

    GameObject gameManager;
    PlayerManager pmManage;          

    GameObject player;
    LeftRightMove lrMove;                //The script that handles left right movement around the scene

    bool posMinus;                       //WHich side if the board the player is on, pulled form the player manager script.
      
    bool canFordsBack;                    //True when th eplayer is within a relevant collider.

   
    // Start is called before the first frame update
    void Start()
    {
        globalAnim = GetComponent<Animator>();

        johnChild = GameObject.Find("Lost John");
        charAnim = johnChild.GetComponent<Animator>();    //Getting the Actual players mesh which the bone animator sits on.

        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();

        player = GameObject.Find("Player");
        lrMove = player.GetComponent<LeftRightMove>();     // Mid level "Player" object which handles movement

    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))   
        {
            canFordsBack = pmManage.canFordsBack;
            if(canFordsBack)
            {
                RunForwardBack();   //Move player forawards and backwards when button pressed
            }
        }
        
    }

    void RunForwardBack()
    {
            posMinus = pmManage.posMinus;     // THis variable stores what side (A or B) the player is on.

            pmManage.isRunningLeft = false;
            pmManage.isRunningRight = false;     //Says that the character is no longer running left or right to prevent stored states causing issues later


            lrMove.enabled = false;   // stops the player from moving left or right when moving forward or back, turned back on using an animation event on the player top level parent object

            if (posMinus)
            {
                charAnim.SetTrigger("crossSideA");       //This first animation is the model animation that makes him look like hes running
                globalAnim.SetTrigger("playerCrossA");   //This animation moves the tope levle player parent object forwards and back.

            }
            else if (!posMinus)
            {
                charAnim.SetTrigger("crossSideB");
                globalAnim.SetTrigger("playerCrossB");   //Same as above
            }
    }

    void LRBackOn()
    {
        lrMove.enabled = true;          //Triggered by an animation event. Allows the palyer to move left and right again once they reach the other side.
        lrMove.distance = 0;
        lrMove.distZ = 0;  //Resets the ditance measurement in the left/right movement script so tha tthe player starts moving in the proper way.

    }
}
