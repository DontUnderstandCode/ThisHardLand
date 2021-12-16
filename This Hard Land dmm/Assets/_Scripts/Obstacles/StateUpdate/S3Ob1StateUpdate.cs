using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S3Ob1StateUpdate : MonoBehaviour
{
    GameObject gameManager;
    ObstacleManager obManage;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        obManage = gameManager.GetComponent<ObstacleManager>();
    }

    void Section3Obstacle1True()
    {
        obManage.s3ob1 = true;   //S refers to section, ob refers to obstacle
    }

    void Section3Obstalce1False()
    {
        obManage.s3ob1 = false;
    }
}
