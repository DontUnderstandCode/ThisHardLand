using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbControl : MonoBehaviour    //This script just contains the function for the animation event, triggering certain thigns for the animation control
{
    GameObject gameManager;
    PlayerManager pmManage;

    GameObject charModel;
    Animator charAnim;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();

        charModel = GameObject.Find("Lost John");
        charAnim = charModel.GetComponent<Animator>();
    }

    void UpdateClimbBool()
    {
        pmManage.doMoveUp = true;
        charAnim.SetBool("isClimbing1", true);

    }
}
    
