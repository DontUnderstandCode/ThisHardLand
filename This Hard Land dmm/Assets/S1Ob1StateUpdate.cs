using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1Ob1StateUpdate : MonoBehaviour         //This script contains methods triggered by aniamtion states so the app can keep track of what puzzle elements are solved.
{
    GameObject gameManager;
    ObstacleManager obManage;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        obManage = gameManager.GetComponent<ObstacleManager>();
    }
    
    void Section1Obstacle1True()
    {
        obManage.s1ob1 = true;   //S refers to section, ob refers to obstacle
    }

    void Section1Obstalce1False()
    {
        obManage.s1ob1 = false;
    }
}
