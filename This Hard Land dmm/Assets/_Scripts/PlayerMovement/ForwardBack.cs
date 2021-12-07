using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardBack : MonoBehaviour   //This script organises and starts the animation tha tmoves the player from one side of theboard to another 
{                                          //It is attatched to the player global parent to allow it to move forward and backward, up or down without having to
                                           //Worry about the players position left or right

    Animator globalAnim;

    GameObject johnChild;
    Animator charAnim;

    GameObject gameManager;
    PlayerManager pmManage;

    GameObject player;
    LeftRightMove lrMove;

    bool posMinus;

    bool canFordsBack;

   
    // Start is called before the first frame update
    void Start()
    {
        globalAnim = GetComponent<Animator>();

        johnChild = GameObject.Find("Lost John");
        charAnim = johnChild.GetComponent<Animator>();    //Getting the Actual players mesh which the bone animator sits on.

        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();

        player = GameObject.Find("Player");
        lrMove = player.GetComponent<LeftRightMove>();

    }


    // Update is called once per frame
    void Update()
    {

        posMinus = pmManage.posMinus;       //This variable stores what side (A or B) the player is on.

        canFordsBack = pmManage.canFordsBack;
        if(Input.GetKeyDown(KeyCode.W))
        {
            pmManage.isRunningLeft = false;
            pmManage.isRunningRight = false;
     

            lrMove.enabled = false;   // stops the player from moving left or right when moving forward or back, turned back on using an animation event on the player top level parent object
            
            if (posMinus)
            {
                charAnim.SetTrigger("crossSideA");       //This first animation is the model animation that makes him look like hes running
                globalAnim.SetTrigger("playerCrossA");   //This animation moves the tope levle player parent object forwards and back.

            }
            else if(!posMinus)
            {
                charAnim.SetTrigger("crossSideB");
                globalAnim.SetTrigger("playerCrossB");
            }
            
        }
      
    }

    void LRBackOn()
    {
        lrMove.enabled = true;          //Triggered by an animation event. Allows the palyer to move left and right again once they reach the other side.
        lrMove.distance = 0;
        lrMove.distZ = 0;  //Resets the ditance measurement in the left/right movement script so tha tthe player starts moving in the proper way.

    }
}
