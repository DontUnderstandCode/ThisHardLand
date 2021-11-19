using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    GameObject  gameManager;
    PlayerManager pmManage;
    Vector3 playerCoord;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();
    }

    void Update()
    {
        playerCoord = pmManage.playerCoord;
        float coordY = playerCoord.y - 1;
        float coordZ = playerCoord.z;
        Vector3 followCoord = new Vector3();
        followCoord.Set(0, coordY, coordZ);
        transform.position = followCoord;

  
    }


}
