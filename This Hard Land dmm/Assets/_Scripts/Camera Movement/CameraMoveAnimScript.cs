using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveAnimScript : MonoBehaviour
{
    GameObject gameManager;
    PlayerManager pmManage;

    Animator cameraAnim;

    bool posMinus;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();
        
        cameraAnim = GetComponent<Animator>();
    }

    void CameraMoveAnimations()
    {
        if (posMinus)
        {
            cameraAnim.SetTrigger("camRot1");
        }
        else if (!posMinus) 
        {
            cameraAnim.SetTrigger("camRot2");
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            posMinus = pmManage.posMinus;
            bool canFordsBack = pmManage.canFordsBack;
            if (canFordsBack)
            {
                CameraMoveAnimations();
            }


        }
    }
}
