using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableForward : MonoBehaviour
{
    GameObject playerGP;    //Refers to the players top level parent object
    GameObject gameManager;            


    ForwardBack forwardBack;
    PlayerManager pmManage;

    // Start is called before the first frame update
    void Start()
    {
        playerGP = GameObject.Find("PlayerGlobalParent");
        forwardBack = playerGP.GetComponent<ForwardBack>();
       
        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();
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
