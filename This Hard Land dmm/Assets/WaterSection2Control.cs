using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSection2Control : MonoBehaviour
{
    GameObject waterSec2;   //This is the second water particle meitter, it is turned on and off depending on the puzzle states

    GameObject gameManager;
    ObstacleManager obManage;

    bool s1ob1;
    bool s1ob2;

    // Start is called before the first frame update
    void Start()
    {
        waterSec2 = GameObject.Find("WaterSection2");

        gameManager = GameObject.Find("GameManager");
        obManage = gameManager.GetComponent<ObstacleManager>();
    }

    void StartSection2()    //This Method is triggered by an animation event on the second obstacle. It turns the second particles system on if the first two are in the correct positions.
    {
        s1ob1 = obManage.s1ob1;
        s1ob2 = obManage.s1ob2;  //Checks the states form the obstalce manager
        if (s1ob1 && s1ob2)
        {
            waterSec2.SetActive(true);
        }

    }
    void StopSection2()
    {
        waterSec2.SetActive(false);
    }


}
