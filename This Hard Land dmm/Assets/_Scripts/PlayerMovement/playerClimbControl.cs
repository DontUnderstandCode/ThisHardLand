using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerClimbControl : MonoBehaviour      //This script contains methods which are triggered by animation events for making the climbing seuqneces work
{
    GameObject gameManager;
    PlayerManager pmManage;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();

    }

    void UpdateClimbBool()
    {
        pmManage.doClimbUp = true;       //Triggered after the "jump and turn" animation of the climb sequecne. USed in the script "ClimbUp"
    }


    void UpdateClimbDownBool()
    {
        pmManage.doClimbDown = true;      //Triggered after the "jump and turn" animation of the climb sequecne. USed in the script "ClimbDown"
    }
}





