using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterObstacleMover : MonoBehaviour
{
    GameObject gameManager;
    ObstacleManager obManage;
    PlayerManager pmManage;

    GameObject charModel;
    Animator charAnim;


    Animator obstacleAnim;

    bool isRitePlace;
    bool posMinus;   //Pulled from player manager to check what side of the board the player is on
    string obstacleName;

    private void Start()
    {
        obstacleAnim = GetComponent<Animator>();

        gameManager = GameObject.Find("GameManager");
        obManage = gameManager.GetComponent<ObstacleManager>();
        pmManage = gameManager.GetComponent<PlayerManager>();

        charModel = GameObject.Find("Lost John");
        charAnim = charModel.GetComponent<Animator>();

    }

    void OnTriggerEnter(Collider obColl)
    {
        if (obColl.gameObject.name == "Player")
        {
            isRitePlace = true;
        }

    }

    private void OnTriggerExit(Collider obCollEx)
    {
        if (obCollEx.gameObject.name == "Player")
        {
            isRitePlace = false;
        }
    }

    private void Update()
    {
        if (isRitePlace)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartPush();
            }
        }

    }

    void StartPush()       //.This method trigger the correct player animation to make him look like hes pushing things. Which one depends what side of the board hes on.
    {
        posMinus = pmManage.posMinus;    //Gets the side of the board the characte is on
        
        obstacleName = gameObject.name;      //Gets the name of the current collider object
        obManage.obstacleName = obstacleName; //Sends it to the manger script. This used to determine what animation state to run when the button is 
                                              //pressed while only requireing one script and one animator controler to operate all the obstacles
        if (posMinus)
        {
            charAnim.SetTrigger("pushSideA");
        }
        else if (!posMinus)
        {
            charAnim.SetTrigger("pushSideB");
        }
    }
}
