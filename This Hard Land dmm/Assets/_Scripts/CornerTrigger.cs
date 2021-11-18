using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerTrigger : MonoBehaviour
{
    GameObject player;          //Refers to player object
    GameObject gameManager;     //Refers to Gamemanager
    CapRotate capRotate;        //Refers to rotaion scripts for enabling / disabling
    PlayerManager pmManage;     // Refers to player manager script for resetting variables


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");              //
        gameManager = GameObject.Find("GameManager");
        capRotate = player.GetComponent<CapRotate>();
        pmManage = gameManager.GetComponent<PlayerManager>();
    }


   //Restrict to player collider
    void OnTriggerStay()
    {
        capRotate.enabled = true;      //Enables rotation script when within trigger zone
    }

    void OnTriggerExit()              
    {
        capRotate.enabled = false;       //Disables trigger script when leavingt trigger zone
        pmManage.hasrot = false;         //Resets the "has rotated?" storage bool to false
        pmManage.whichWay = 0;           //Resets the "which side hit?" variable to zero to prevent thje player from rotating the wrong way
    }


}
