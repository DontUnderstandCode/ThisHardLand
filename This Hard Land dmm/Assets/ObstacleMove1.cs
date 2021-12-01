using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove1 : MonoBehaviour   //THis script moves the fisrt obstalce and rotates the water collider when the obstacle is clicked
{

    GameObject gameManager;
    ObstacleManager obManage; //obManage is the obstalce manager script that stores the states of the obstacles 

    GameObject plane1;

    bool plane1Mvd = false;
    bool isRightPlace;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        obManage = gameManager.GetComponent<ObstacleManager>();

        plane1 = GameObject.Find("WSection1Plane1");
    }

    void CheckRightPlace()
    {
        isRightPlace = obManage.isRightPlace;
        if(isRightPlace)
        {
            MovePlane1();
        }
    }

    void MovePlane1()
    {
        plane1Mvd = obManage.plane1Mvd;
        if (!plane1Mvd)
        {
            plane1.transform.Rotate(84, 0, 0);
            transform.Translate(0, 0, -0.05f);
            obManage.plane1Mvd = true;
        }
        else if (plane1Mvd)
        {
            plane1.transform.Rotate(-84, 0, 0);
            transform.Translate(0, 0, 0.05f);
            obManage.plane1Mvd = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckRightPlace();
        }
    }



}

