using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightEnableDisable : MonoBehaviour //THis script contains methods to disable left/right movement to be triggered by animation events.
{                                                  
    GameObject player;
    LeftRightMove lrMove;
    
    

    void Start()
    {
        player = GameObject.Find("Player");
        lrMove = player.GetComponent<LeftRightMove>();   //This is the mid level character parent object "Player" responsible for movement
    }

    void EnableLeftRight()
    {
        lrMove.enabled = true;
    }

    void DisableLeftRight()
    {
        lrMove.enabled = false;
    }

}
