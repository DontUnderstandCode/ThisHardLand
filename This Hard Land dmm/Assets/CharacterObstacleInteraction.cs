using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterObstacleInteraction : MonoBehaviour
{
    string obstacleName;

    GameObject gameManager;
    ObstacleManager obManage;

    GameObject waterObstacle;
    Animator obstacleAnim;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        obManage = gameManager.GetComponent<ObstacleManager>();
    }

    void TriggerObstacleMovement()            // This method takes the name of the relevant obstacle, refers to it's animator, and uses its name as a trigger to set the correct animation in motion
    {                                         //trigger to set the correct animation in motion
        obstacleName = obManage.obstacleName;              //Pulls obstaclename from t he obstacle manager script
        waterObstacle = GameObject.Find(obstacleName);         
        obstacleAnim = waterObstacle.GetComponent<Animator>();   //USes the ob name to refer to the correct GameObject and Animator
        obstacleAnim.SetTrigger(obstacleName);             //Sets a trigger which is the same as the objects name


    }


}
