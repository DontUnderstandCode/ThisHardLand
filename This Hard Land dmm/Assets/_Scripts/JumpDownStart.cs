using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDownStart : MonoBehaviour
{
    GameObject gameManager;
    PlayerManager pmManage;

    GameObject charModel;
    Animator charAnim;

    bool canJumpDown;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();

        charModel = GameObject.Find("Lost John");
        charAnim = charModel.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider jmpDown)
    {
        if(jmpDown.gameObject.name == "Player")
        {
            pmManage.canJumpDown = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        canJumpDown = pmManage.canJumpDown;   
        if(canJumpDown)
        {
            JumpDown();
        }
    }

    void JumpDown()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {   
            charAnim.SetTrigger("jumpDown1");

        }
        
            

    }
}
