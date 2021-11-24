using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbUp : MonoBehaviour     //This script checks whether the player is within the "climb" collider and sets in motion the animations and methods to make the player climb a level
{
    GameObject playerGP;   //Refers to the parent object of the player
    Animator globalAnim;      //Refers to the animator of the player parent object, to move it forwards and backwards.

    GameObject gameManager;
    PlayerManager pmManage;

    GameObject player;

    GameObject charModel;
    Animator charAnim;

    bool doMoveUp = false;
    // Start is called before the first frame update
    void Start()
    {
        playerGP = GameObject.Find("PlayerGlobalParent");
        globalAnim = playerGP.GetComponent<Animator>();

        player = GameObject.Find("Player");

        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();

        charModel = GameObject.Find("Lost John");
        charAnim = charModel.GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider climbUp)
    {
        if (climbUp.gameObject.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                globalAnim.SetTrigger("playerClimbUp1");

            }
            
            PLRMoveUp();
        }
    }

    private void OnTriggerExit(Collider climbStop)
    {
        pmManage.doMoveUp = false;
        charAnim.SetBool("isClimbing1", false);
    }

    void PLRMoveUp()
    {
        if(doMoveUp)
        {
            int speed = 1;
            player.transform.Translate(0, speed * Time.deltaTime, 0);
        }
  
    }



    // Update is called once per frame
    void Update()
    {
        doMoveUp = pmManage.doMoveUp;

        
    }
}
