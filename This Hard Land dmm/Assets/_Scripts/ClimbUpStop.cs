using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbUpStop : MonoBehaviour
{
    GameObject gameManager;
    PlayerManager pmManage;  //Rfers to the player manager

    GameObject player;  //Gets the Player Object


    GameObject charModel;
    Animator charAnim;      //Gets teh character model animator to start and stop animations

    Vector3 playerCoord;
    Vector3 trggrCoord;
    Vector3 charCoord;

    bool shdMoveTop;



    
    void Start()
    {
        trggrCoord = transform.position;

        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();

        player =GameObject.Find("Player");

        charModel = GameObject.Find("Lost John");
        charAnim = charModel.GetComponent<Animator>();
    }


    void OnTriggerEnter()
    {
        pmManage.shouldClimb = false;
        pmManage.doClimb = false;
        charAnim.SetTrigger("jump2Top1");
    }


    void Update()
    {
        playerCoord = pmManage.playerCoord;
        charCoord = charModel.transform.position;
        shdMoveTop = pmManage.shdMoveTop;

        
        if(shdMoveTop)
        {
            MoveToLevel();
        }
    }

    void MoveToLevel()
    {

        player.transform.position = trggrCoord;

        pmManage.shdMoveTop = false;

        

    }

}

