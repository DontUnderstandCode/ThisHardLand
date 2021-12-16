using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s3ob3StateUpdate : MonoBehaviour
{
    GameObject gameManager;
    ObstacleManager obManage;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        obManage = gameManager.GetComponent<ObstacleManager>();
    }

    void Section3Obstacle3True()
    {
        obManage.s3ob3 = true;   //S refers to section, ob refers to obstacle
    }

    void Section3Obstalce3False()
    {
        obManage.s3ob3 = false;
    }
}
