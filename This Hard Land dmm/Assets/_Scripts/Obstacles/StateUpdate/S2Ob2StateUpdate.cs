using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2Ob2StateUpdate : MonoBehaviour
{
    GameObject gameManager;
    ObstacleManager obManage;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        obManage = gameManager.GetComponent<ObstacleManager>();
    }

    void Section1Obstacle2True()
    {
        obManage.s2ob2 = true;   //S refers to section, ob refers to obstacle
    }

    void Section1Obstalce2False()
    {
        obManage.s2ob2 = false;
    }
}
