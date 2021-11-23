using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject gameManager;
    PlayerManager pmManage;
    //Vector3 playerCoord;
    //float SmoothdX;

    bool posMinus;

    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();

      
        //playerCoord = pmManage.playerCoord;
    }

    //void PlayerPosConvert()   //The purpose of this method is to take the players X position and convert that into a useable value for panning the camera
    //{
       // playerCoord = pmManage.playerCoord;
        //float playerX = playerCoord.x;
        //playerX = -1 * Mathf.Sqrt(playerX * playerX);   //This line takes in the player X position which could be positive or negatice and makes sure it is always negative
       // SmoothdX = Mathf.Sqrt((-1 *playerX) / 0.32f);           //This line uses the parabolic equation to convert the input from the playerX position to a value that can be  used to move the camera
    //}

    //void CameraTranslate()
    //{
        //bool playerXDir = pmManage.playerXDir;
        //if(playerXDir)
        //{
           // if(posMinus)
            //{
                //transform.Translate( 0 , 0, -3* SmoothdX * Time.deltaTime);
            //}
           // else if(!posMinus)
            //{
                //transform.Translate( 0 , 0, 3* SmoothdX * Time.deltaTime);
            //}
       // }   
        //else if(!playerXDir)
        //{
            //if(posMinus)
            //{
                //transform.Translate( 0 , 0, 3* SmoothdX * Time.deltaTime);
            //}
           // else if(!posMinus)
            //{
                //transform.Translate( 0 , 0, -3* SmoothdX * Time.deltaTime);
            //}
        //}


    //}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            posMinus = pmManage.posMinus;
            bool canFordsBack = pmManage.canFordsBack;
            if(canFordsBack)
            {
                //PlayerPosConvert();
                //CameraTranslate();
            }
        
       
        }
    }
}
