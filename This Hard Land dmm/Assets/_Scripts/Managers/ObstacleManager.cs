using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour //This script is similar to the player manager script and is used to store information about the obstacle states that can be used anywhere
{
    public string obstacleName;     //This is the name of the obstacle the player is currently dealing with. This string is filled whjen the player triggers the obstacle.

    public bool s1ob1;
    public bool s1ob2;



    
    public bool s2ob1;
    public bool s2ob2;

    public bool s3ob1;
    public bool s3ob2;
    public bool s3ob3;

    public bool sec1;
    public bool sec2;
    public bool sec3;

    public bool puzzleComplete = false;


}
