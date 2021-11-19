using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorUpdate : MonoBehaviour  //The purpose of this script is to send various useful updates about the player position and movement to the player manager script
{
    GameObject gameManager;
    PlayerManager pmManage;
    float playerX1;
    float playerX2;
    float playerXDir;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();
 
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 playerCoord = transform.position;
        pmManage.playerCoord = playerCoord;     //This is just the Vector3 of the player position
        if(playerCoord.x > 0)            //This If/else combo sets a bool which determines which side of the puzzle the player is on
        {
            pmManage.posMinus = true;
        }
        else
        {
            pmManage.posMinus = false;
        }
        
        playerX1 = playerCoord.x;    //This takes a reading of player X position
    }
    
    void LateUpdate()
    {
        playerX2 = transform.position.x;     //This takes a second reading of player X position
        playerXDir = playerX1 - playerX2;          //This subtracts the two readings resulting in eithe a positive or negative value depending on which way the player is moving
        if(playerXDir > 0)                         //This if/else combo converts the resulting playerXDir value to a bool for storage. This is so that it can be used less expensively in multiple scripts.
        { 
            pmManage.playerXDir = true;
        }
        else if(playerXDir <0)
        {
            pmManage.playerXDir = false;
        }
    print(pmManage.playerXDir);
    }


        
    
}
