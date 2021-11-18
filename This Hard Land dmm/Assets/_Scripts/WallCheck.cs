using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    GameObject gameManager;
    PlayerManager pmManage;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();
    }

    Vector3 playerDir;    //Establishes space for storing player directgion
    private float whichWay;

    private void OnCollisionEnter(Collision wallcollide)    //Called when the player hits a wall collider
    {

        Vector3 collDir = wallcollide.contacts[0].normal;     //fills a vedctor3 variable with the normal direction of the contact
        playerDir = transform.InverseTransformDirection(collDir);    //Transforms the vector into the local space of the player
        whichWay = playerDir.x;                    //Fills the "whichWay" float with the localised value
        pmManage.whichWay = whichWay;              //Sends this value to the player manager script
    }
}
