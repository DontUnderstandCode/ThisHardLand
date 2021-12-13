using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterObstacleMover : MonoBehaviour  //This script is respnsible for registering when the player is in the correct position and starting the animation seuqnece that moves the obstacles
{
    GameObject gameManager;
    ObstacleManager obManage;
    PlayerManager pmManage;            //GameManager Object and assosiacted manager scripts

    GameObject player;
    LeftRightMove lrMove;

    GameObject charModel;
    Animator charAnim;                 //character model and associated animator


    Animator obstacleAnim;            //Creating space for the animator on "this" object

    bool isRitePlace;  
    bool posMinus;        //Pulled from player manager to check what side of the board the player is on
    string obstacleName;  //Is the name of this object, filled further down \/

    private void Start()
    {
        obstacleAnim = GetComponent<Animator>();         //Gets the animator for this object

        gameManager = GameObject.Find("GameManager");
        obManage = gameManager.GetComponent<ObstacleManager>();
        pmManage = gameManager.GetComponent<PlayerManager>();    //Getting the manager scripts

        player = GameObject.Find("Player");
        lrMove = player.GetComponent<LeftRightMove>();            //Gets the Player parent obejct to disable left and right movement while the aniomation runs.

        charModel = GameObject.Find("Lost John");
        charAnim = charModel.GetComponent<Animator>();           //Getting the character model and animator
    }

    void OnTriggerEnter(Collider obColl)
    {
        if (obColl.gameObject.name == "Player")
        {
            isRitePlace = true;              //switches state to true if the player is in front of the obstacle
        }

    }

    private void OnTriggerExit(Collider obCollEx)
    {
        if (obCollEx.gameObject.name == "Player")
        {
            isRitePlace = false;               //Switches to off if not
        }
    }

    private void Update()
    {
        if (isRitePlace)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                lrMove.enabled = false;      //Turns of left and right movement while the animation runs, turned back on ny aniamtion event on the player character model.
                StartPush();                 //If the player is in front of the obstacle, and the player pushes the button, start the "push obstacle" sequence
            }
        }

    }

    void StartPush()       //.This method trigger the correct player animation to make him look like hes pushing things. Which one depends what side of the board hes on.
    {
        posMinus = pmManage.posMinus;    //Gets the side of the board the characte is on
        
        obstacleName = gameObject.name;      //Gets the name of the collider this script is atatched to
        obManage.obstacleName = obstacleName; //Sends it to the manager script. This used to determine what animation state to run when the button is 
                                              //pressed while only requireing one script and one animator controler to operate all the obstacles
        if (posMinus)
        {
            charAnim.SetTrigger("pushSideA");   //Start the correct animation depending what side of the board the player is on
        }
        else if (!posMinus)
        {
            charAnim.SetTrigger("pushSideB");
        }
    }
}
