using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerClimbControl : MonoBehaviour      //This script contains methods which are triggered by aniamtion events for making the climbing and jumping sequence work.
{
    GameObject gameManager;
    PlayerManager pmManage;
//////////////////////////////////////////////////

////////////////////////////////////////////////

    GameObject player;
    LeftRightMove lrMove;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();

        player = GameObject.Find("Player");
        lrMove = player.GetComponent<LeftRightMove>();


    }

    void UpdateClimbBool()
    {
        pmManage.doClimbUp = true;
    }

    void UpdateLeftRightEnable()
    {
        lrMove.enabled = true;      


    }

    void UpdateClimbDownBool()
    {
        pmManage.doClimbDown = true;
    }



}





