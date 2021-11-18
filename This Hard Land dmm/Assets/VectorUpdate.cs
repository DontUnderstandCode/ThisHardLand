using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorUpdate : MonoBehaviour
{
    GameObject gameManager;
    PlayerManager pmManage;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerCoord = transform.position;
        pmManage.playerCoord = playerCoord;
    }
}
