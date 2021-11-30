using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerClimbControl : MonoBehaviour      //This script contains methods which are triggered by aniamtion events for making the climbing and jumping sequence work.
{
    GameObject gameManager;
    PlayerManager pmManage;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();

        player = GameObject.Find("Player");
    }

    void UpdateClimbBool()
    {
        pmManage.doClimb = true;
        
    }

    void UpdateEndOfJump()
    {
        pmManage.shdMoveTop = true;
    }

    void ResetParentDown()
    {
        Transform playerTrs = player.transform;
        transform.SetParent(playerTrs, false);
        player.transform.position = transform.position;
        transform.SetParent(playerTrs, true);
        pmManage.canJumpDown = false;

    }


}
