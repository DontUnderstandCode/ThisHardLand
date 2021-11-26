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

    void MoveToLevel()
    {
        player.transform.position = trggrCoord;
        charModel.transform.position = player.transform.position;
        pmManage.shdMoveTop = false;
  
        //player.transform.position = Vector3.MoveTowards(playerCoord, trggrCoord, 0.03f);
        
    }


    void Update()
    {
        playerCoord = pmManage.playerCoord;
        shdMoveTop = pmManage.shdMoveTop;

        if(shdMoveTop)
        {
            MoveToLevel();
        }
    }
}

