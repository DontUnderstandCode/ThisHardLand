using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterParticleControl : MonoBehaviour  //This script contains methods for enabling and disabling the particle systems
{                                                  //Different "Stop" methods are required so that lower obstacles don't turn off upper water systems
                                                   //The script is written to ensure that the water behaves properly, and if the flow us cut off higher up then it will stop all the way 
                                                   //down, and likewise if its turned on at the top it will turn on all the way down
    
    GameObject waterSec2;   //This is the second water particle meitter, it is turned on and off depending on the puzzle states
    ParticleSystem waterPart2;

    GameObject waterSec3;   //This is the second water particle meitter, it is turned on and off depending on the puzzle states
    ParticleSystem waterPart3;

    GameObject waterSec4;
    ParticleSystem waterPart4;

    GameObject gameManager;
    ObstacleManager obManage;

    bool s1ob1;   //Local declarations of Obstalce states from the obstalce manager
    bool s1ob2;
    bool s2ob1;
    bool s2ob2;
    bool s3ob1;
    bool s3ob2;
    bool s3ob3;

    bool sec1;
    bool sec2;
    bool sec3;   //These are used to organise the obstacle states into sections

    // Start is called before the first frame update
    void Start()
    {
        waterSec2 = GameObject.Find("WaterSection2");
        waterPart2 = waterSec2.GetComponent<ParticleSystem>();

        waterSec3 = GameObject.Find("WaterSection3");
        waterPart3 = waterSec3.GetComponent<ParticleSystem>();

        waterSec4 = GameObject.Find("WaterSection4");
        waterPart4 = waterSec4.GetComponent<ParticleSystem>();

        gameManager = GameObject.Find("GameManager");
        obManage = gameManager.GetComponent<ObstacleManager>();

        waterPart2.Stop();
        waterPart3.Stop();
        waterPart4.Stop();   //The water should be off when the script loads
    }


    //////////////////////////////////////////////////////////////////////////////////////////


    void StartSection()          //This Method is triggered by an animation event in the obstalce animations. It checks the various obstalce states and then calles the method below
                                 //that turns particle systems on according to the puzzle status
    {
        s1ob1 = obManage.s1ob1;
        s1ob2 = obManage.s1ob2;  //Checks the states form the obstacke manager
        s2ob1 = obManage.s2ob1;
        s2ob2 = obManage.s2ob2;
        s3ob1 = obManage.s3ob1;
        s3ob2 = obManage.s3ob2;
        s3ob3 = obManage.s3ob3;

        if(s1ob1 && s1ob2)    //This series of if statements organises obstacle states into sections for neatness and useability
        {
            sec1 = true;
            obManage.sec1 = true;
        }
        else
        {
            sec1 = false;
            obManage.sec1 = false;   //Necassary to make sure there aren't false positives when doing the check
        }

        if(s2ob1 && s2ob2)
        {
            sec2 = true;
            obManage.sec2 = true;
        }
        else
        {
            sec2 = false;
            obManage.sec2 = false;
        }

        if (s3ob1 && s3ob2 && s3ob3)
        {
            sec3 = true;
            obManage.sec3 = true;
        }
        else
        {
            sec3 = false;
            obManage.sec3 = false;
        }

        SelectStartParticle();  //This runs the next step, which is what actually starts the particle systems

    }

    void SelectStartParticle()     //This function is split off just for code neatness and legibility
    {
        if(sec1 && sec2 && sec3)   //Checks puzzle obstacle states and starts particle systems accordingly
        {
            waterPart2.Play();
            waterPart3.Play();
            waterPart4.Play();
        }
        else if (sec1 && sec2)
        {
            waterPart2.Play();
            waterPart3.Play();
        }

        else if (sec1)
        {
            waterPart2.Play();
        }
    }


    ////////////////////////////////////////////////////////////////////////////

    
    void StopSection2()   //This is used for objects in the first "Section"   The reason they use different functions is because of the logic of how water flows
    {                         //If the top object is turned, all the water flow below it must stop
        waterPart2.Stop();
        waterPart3.Stop();
        waterPart4.Stop();   
    }

    void StopSection3()     //This is used for objects in the second "Section" 
    {
        waterPart3.Stop();
        waterPart4.Stop();
    }

    void StopSection4()
    {
        waterPart4.Stop();
    }


}
