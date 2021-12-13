using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableLeftRIght : MonoBehaviour
{
    GameObject gameManager;
    PlayerManager pmManage;

    GameObject player;
    LeftRightMove lrMove;    //This is the left right movement script atatched to the "Player" parent object


    void Start()
    {

        player = GameObject.Find("Player");
        lrMove = player.GetComponent<LeftRightMove>();      //This fetches the "player"obejct which controls the players movement in-plane, and the script that makes it work.

        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();
    }


    void UpdateLeftRightEnable()           //The left right movement is disabled in the "ClimbUp" and "ClimbDown" scripts. This method is called when the climb sequence is finished alowing the palyer to move left tand right again.
    {                                      //This method is called when the climb sequence is finished alowing the palyer to move left tand right again.
        pmManage.isRunningRight = false;
        pmManage.isRunningLeft = false;    //States that the player is not running initally in case of stored states from the staart of the climb sequence
        lrMove.enabled = true;             //Enables script
        lrMove.distance = 0;
        lrMove.distZ = 0;                  //Says that the distance travedlled starts from 0. Important to gurantee that the starting speed is correc (See "LeftRightMove" script)
    }

}
