using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour  //THis script takes the y and Z (look at plane) components of the player character model and makes the camera parent object follow it
{                                          //The camera parenbt obect is rotated to change the camera angle by way of animations
    GameObject  gameManager;
    PlayerManager pmManage;
    Vector3 charCoord;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();
    }

    void Update()
    {

        charCoord = pmManage.charCoord;
        float coordY = charCoord.y - 1;
        float coordZ = charCoord.z;
        Vector3 followCoord = new Vector3();
        followCoord.Set(0, coordY, coordZ);





        transform.position = followCoord;

  
    }


}
