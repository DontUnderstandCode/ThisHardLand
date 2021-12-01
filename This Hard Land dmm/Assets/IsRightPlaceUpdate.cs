using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsRightPlaceUpdate : MonoBehaviour             //This script sets the public bool which says whether the player can interact with an object or not
{
    GameObject gameManager;
    ObstacleManager obManage;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        obManage = gameManager.GetComponent<ObstacleManager>();
    }

    private void OnTriggerEnter(Collider rightPlace)
    {
        obManage.isRightPlace = true;                //Updates true when in the trigger space
    }

    private void OnTriggerExit(Collider notRightPlace)
    {
        obManage.isRightPlace = false;                //Updates false when in the trigger space
    }
}
