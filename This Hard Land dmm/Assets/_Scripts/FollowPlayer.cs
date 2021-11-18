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

    void FixedUpdate()
    {
        playerCoord = pmManage.playerCoord;
        float coordY = playerCoord.y;
        float coordZ = playerCoord.z;
        print(coordY);
        print(coordZ);
        transform.position.Set(0, coordY, coordZ);
    }


}
