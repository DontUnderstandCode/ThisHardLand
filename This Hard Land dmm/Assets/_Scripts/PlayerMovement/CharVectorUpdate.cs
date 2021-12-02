using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharVectorUpdate : MonoBehaviour
{
    GameObject gameManager;
    PlayerManager pmManage;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        pmManage.charCoord = transform.position;

    }
}
