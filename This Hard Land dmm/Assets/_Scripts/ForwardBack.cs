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
    }


    // Update is called once per frame
    void Update()
    {
        posMinus = pmManage.posMinus;

        canFordsBack = pmManage.canFordsBack;
        if(Input.GetKeyDown(KeyCode.W))
        {
            if (posMinus)
            {
                charAnim.SetTrigger("crossSide1");
                globalAnim.SetTrigger("playerCross1");

            }
            else if(!posMinus)
            {
                charAnim.SetTrigger("crossSide2");
                globalAnim.SetTrigger("playerCross2");
            }
            
        }
      
    }
}
