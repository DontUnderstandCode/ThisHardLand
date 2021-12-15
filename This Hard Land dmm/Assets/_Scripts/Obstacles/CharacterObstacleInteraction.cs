using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterObstacleInteraction : MonoBehaviour  //This script contains the method triggered by the player character "push" animation. 
                                                           //The purpose is to be able to use the same script and Animation event ot trgger all the different obstacles, 
                                                           //making it cleaner and easier to implement
{
    string obstacleName;     //This is filled with the name of the obstacle collider from the obstacle manager

    GameObject gameManager;
    ObstacleManager obManage;

    GameObject player;
    LeftRightMove lrMove;

    GameObject waterObstacle;
    Animator obstacleAnim;      //Creating space for the obstacle and its associated animator and audi source
    AudioSource obstacleSound;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        obManage = gameManager.GetComponent<ObstacleManager>(); 
    }

    void TriggerObstacleMovement()            // This method is triggered by an animation event on the character model. It retrieves the obstacle name sent by the obstacle, uses it to refer to the correct GameObject and Animator
    { 
        obstacleName = obManage.obstacleName;              //Pulls obstaclename from the obstacle manager script
        waterObstacle = GameObject.Find(obstacleName);         
        obstacleAnim = waterObstacle.GetComponent<Animator>();   //USes the ob name to refer to the correct GameObject and Animator
        obstacleSound = waterObstacle.GetComponent<AudioSource>();  //Gets the audio source also
        obstacleAnim.SetTrigger(obstacleName);             //Sets a trigger which is the same as the objects name
        obstacleSound.Play(0);
    }

}
