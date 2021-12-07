using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimContol : MonoBehaviour       //This script determines which running animation should be played depending which way he's going.
{
    GameObject gameManager;
    PlayerManager pmManage;

    Animator charAnim;

    bool isRunningLeft;
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
        isRunningRight = pmManage.isRunningRight;
        
        if (isRunningLeft)
        {
            charAnim.SetBool("isRunningL", true);
            charAnim.SetBool("isRunningR", false);
        }
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
