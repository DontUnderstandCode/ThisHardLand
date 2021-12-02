using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimContol : MonoBehaviour
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
        }
        else if(isRunningRight)
        {
            charAnim.SetBool("isRunningR", true);
        }
        else
        {
            charAnim.SetBool("isRunningL", false);
            charAnim.SetBool("isRunningR", false);
        }
    }

}
