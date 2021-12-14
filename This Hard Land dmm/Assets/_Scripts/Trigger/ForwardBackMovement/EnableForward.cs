using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableForward : MonoBehaviour      //This script is places on trigger colliders in the scene. The script allows the player to move back and forth across the two sides 
{                                               //of the board when the button is pressed. 
    
    GameObject playerGP;    //Refers to the players top level parent object
    GameObject gameManager;            


    ForwardBack forwardBack;  //This is the script ont he top level player movement object "player global parent". It is disabled and enabled form this script at the appropraite times.
    PlayerManager pmManage;

    // Start is called before the first frame update
    void Start()
    {
        playerGP = GameObject.Find("PlayerGlobalParent");
        forwardBack = playerGP.GetComponent<ForwardBack>();
       
        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();

        pmManage.canFordsBack = false;  //Set to false when the script starts tso the charcater cant move forwards and back until he actually runs in to one of these triggers
    }

    void OnTriggerStay()
    {
        forwardBack.enabled = true; 
        pmManage.canFordsBack = true;         //Lets the player move in and out of the scene 

    }

    void OnTriggerExit()
    {
        forwardBack.enabled = false;
        pmManage.canFordsBack = false;        //Does the reverse when the player is outside the trigger area
    }


}
