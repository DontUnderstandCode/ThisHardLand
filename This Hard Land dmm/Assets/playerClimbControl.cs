using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerClimbControl : MonoBehaviour
{
    GameObject gameManager;
    PlayerManager pmManage;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();
    }

    void UpdateClimbBool()
    {
        pmManage.shouldClimb = true;
    }

    void UpdateClimbStartJump()
    {
        pmManage.shdMoveTop = true;
    }

    void UpdateClimbStopJump()
    {
        pmManage.shdMoveTop = false;
    }

}
