using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubbleTrigger : MonoBehaviour    //This script sits on certain interactable objects (The first ones to be encountered), Activates the speech bubbles that explain the controls
{
    GameObject gameManager;
    ObstacleManager obManage;     //This is the obstacle manager script on the GameManager object

    GameObject bubbleParent;
    Animator bubbleAnim;          //This is the speech bubble parent object and associated animator

    string obBubbleName;  

    bool hasClimbBubble;
    bool hasForwardsBubble;
    bool hasObstacleBubble;

    // Start is called before the first frame update
    void Start()       //Getting the required objects and animators
    {
        gameManager = GameObject.Find("GameManager");
        obManage = gameManager.GetComponent<ObstacleManager>();

        bubbleParent = GameObject.Find("SpeechBubbleParent");
        bubbleAnim = bubbleParent.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider speechBubble)     //This is triggered when the palyer collides with an object this script is on, the first of each they encounter
    {
        hasForwardsBubble = obManage.hasForwardsBubble;     
        hasClimbBubble = obManage.hasClimbBubble;
        hasObstacleBubble = obManage.hasObstacleBubble;   //Pulls the state of these bools form the Obstacle Manager script

        if (speechBubble.gameObject.name == "Player")   //Checks that the collision was with the player
        {
            CheckCollName(); 
        }
    }

    void CheckCollName()    //Gets the name of the current collider object so that the correct bubble can be displayed
    {
        obBubbleName = gameObject.name;

        StartBubbleDisplay();
    }

    void StartBubbleDisplay()     //Picks a bubble to be diplayed
    {
        if(obBubbleName == "ForwardEnable 1" && !hasForwardsBubble)   //Checks that the speech bubble has not been displayued already, if so, passes over
        {
            bubbleAnim.SetTrigger("wForwards");
            obManage.hasForwardsBubble = true;    //Updates the manager script once its been displayed, so that even if the player leaves the scene it wont happen again.
        }
        else if(obBubbleName == "ClimbUpB" && !hasClimbBubble)
        {
            bubbleAnim.SetTrigger("wClimb");
            obManage.hasClimbBubble = true;
        }
        else if(obBubbleName == "Section1Ob1" && !hasObstacleBubble)
        {
            bubbleAnim.SetTrigger("shiftObstacle");
            obManage.hasObstacleBubble = true;
        }
        
    }
}
