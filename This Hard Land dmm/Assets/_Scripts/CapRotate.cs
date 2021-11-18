using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapRotate : MonoBehaviour
{
    GameObject gameManager;
    PlayerManager pmManage;
    CapRotateDefine  rotDefine;
    public float whichWay;   //Gets the localised collision direction from the Wall Check script
    public bool hasrot;

    
    private void Start()
    {
        rotDefine = GetComponent<CapRotateDefine>();
        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();
        hasrot = false;         //In the first place the player has not rotated

    }

    void Rotator()       //Decides which way to turn the player based on the collision direction. Refers to methods defined in anotehr script
    {
        if (whichWay < -0.9f)
        {
            rotDefine.RotateClock();
        }
        else if (whichWay > 0.9f)
        {
            rotDefine.RotateAntiClock();
        }
    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            whichWay = pmManage.whichWay;
            Rotator();
        }
      
    }
}
