using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour //This script is similar to the player manager script and is used to store information about the obstacle states that can be used anywhere
{
    public string obstacleName;     //This is the name of the obstacle the player is currently dealing with. This string is filled whjen the player triggers the obstacle.

    public bool s1ob1;         //These bools store the states of indivudual obstacles. They are true when the obstacle is in the right place
    public bool s1ob2;
    
    public bool s2ob1;
    public bool s2ob2;

    public bool s3ob1;
    public bool s3ob2;
    public bool s3ob3;

    public bool sec1;          //These bools are used in the Particle System Controler script to organise the sections and make code neater
    public bool sec2;
    public bool sec3;

    public bool puzzleComplete = false;   //This is true when all the obstacle parts are in the right palce

    public bool hasClimbBubble;   //These bool are used to remember whether or not the explanatory speech bubble has been displayed or not.
    public bool hasForwardsBubble;   //THey are in the manager script so that their states do not get wiped if the player leaves the main scene
    public bool hasObstacleBubble;


}
