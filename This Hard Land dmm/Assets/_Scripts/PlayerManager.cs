using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour              //This script is used as a publicly accesable repository of player position and movement information for use between interacting scripts
{
    
    
    //////////////////////////////////////-Below are some variables relating to the characters position and whether and where they can move
    public Vector3 playerCoord;

    public bool canFordsBack;       //This is true when the character is at the entrance to a tunnel, if true the character can move through the tunnel

    public bool posMinus;         //This is true or false depending what side of the board the character is on
    ///////////////////////////////////////////////////////

    public bool playerXDir;// This is set up as a bool so that it can be used in multiple other update functions with less computing power. True means its travelling one way false means travelling the other
   
    ///////////////////////////////////////////-Below are bool switches relating to the characters movement left and right, used for animations

    public bool isRunningLeft;   

    public bool isRunningRight;   //Are true or false when the character is running in the respective direction


//////////////////////////////////////-Below are bool switches related to the character climbing sequence
    public bool shouldClimb; 
    public bool stopClimb;
    public bool shdMoveTop;
    public bool doClimb;



}
