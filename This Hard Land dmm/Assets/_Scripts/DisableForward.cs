using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableForward : MonoBehaviour
{
    GameObject player;
    GameObject gameManager;

    ForwardBack forwardBack;
    PlayerManager pmManage;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        forwardBack = player.GetComponent<ForwardBack>();
        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();
    }

    void OnTriggerStay()
    {
        forwardBack.enabled = false;
        pmManage.canFordsBack = false;
    }

    void OnTriggerExit()
    {
        forwardBack.enabled = true;
        pmManage.canFordsBack = true;
    }


}
