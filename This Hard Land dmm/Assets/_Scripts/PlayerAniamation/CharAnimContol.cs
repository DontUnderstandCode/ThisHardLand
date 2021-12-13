using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimContol : MonoBehaviour       //This script determines which running animation should be played depending which way the players going.
{
    GameObject gameManager;
    PlayerManager pmManage;      //The player manager script which stores player movement information

    Animator charAnim;          //The animator atatched to the character model

    bool isRunningLeft;        //These are triggered respectively when the parent "Player" object is moving left or right
    bool isRunningRight;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();

        charAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        isRunningLeft = pmManage.isRunningLeft;
        isRunningRight = pmManage.isRunningRight;     //Checks each frame to see whether the player is moving according to player manager script
        
        if (isRunningLeft)
        {
            charAnim.SetBool("isRunningL", true);
            charAnim.SetBool("isRunningR", false);    //These if else statements trigger animations depending on which way the player is running. 
        }                                             //Does not require to check which side of the board the player is on because the movement script already accounts for that
        else if(isRunningRight)
        {
            charAnim.SetBool("isRunningR", true);
            charAnim.SetBool("isRunningL", false);
        }
        else
        {
            charAnim.SetBool("isRunningL", false);
            charAnim.SetBool("isRunningR", false);
        }
    }

}
