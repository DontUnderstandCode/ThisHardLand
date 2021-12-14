using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterParticleControl : MonoBehaviour  //This script contains methods for enabling and disabling the particle systems
{                                                  //Different "Stop" methods are required so that lower obstacles don't turn off upper water systems

    GameObject waterSec2;   //This is the second water particle meitter, it is turned on and off depending on the puzzle states
    ParticleSystem waterPart2;

    GameObject waterSec3;   //This is the second water particle meitter, it is turned on and off depending on the puzzle states
    ParticleSystem waterPart3;

    GameObject gameManager;
    ObstacleManager obManage;

    bool s1ob1;
    bool s1ob2;
    bool s2ob1;
    bool s2ob2;

    // Start is called before the first frame update
    void Start()
    {
        waterSec2 = GameObject.Find("WaterSection2");
        waterPart2 = waterSec2.GetComponent<ParticleSystem>();

        waterSec3 = GameObject.Find("WaterSection3");
        waterPart3 = waterSec3.GetComponent<ParticleSystem>();

        gameManager = GameObject.Find("GameManager");
        obManage = gameManager.GetComponent<ObstacleManager>();

        waterPart2.Stop();
        waterPart3.Stop();
    }

    void StartSection()    //This Method is triggered by an animation event on the second obstacle. It turns the second particles system on if the first two are in the correct positions.
    {
        s1ob1 = obManage.s1ob1;
        s1ob2 = obManage.s1ob2;  //Checks the states form the obstalce manager
        s2ob1 = obManage.s2ob1;
        s2ob2 = obManage.s2ob2;

       

        if (s1ob1 && s1ob2 && s2ob1 && s2ob2)
        {
            waterPart2.Play();
            waterPart3.Play();
        }

        if (s1ob1 && s1ob2)
        {
            waterPart2.Play();
        }

    }


    
    void StopSection2()
    {
        waterPart2.Stop();
        waterPart3.Stop();
    }

    void StopSection3()
    {
        waterPart3.Stop();
    }


}
