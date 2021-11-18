using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapRotateDefine : MonoBehaviour   //This script defines the methods for rotating clockwise and antoclockwise as referenced by the rotation controler script "CapRotate"
{ 
    GameObject gameManager;
    PlayerManager pmManage;
    Animator rotAnim;
    
    bool hasrot;
    
    // Start is called before the first frame update
    void Start()
    {
        hasrot = false;
        gameManager = GameObject.Find("GameManager");
        pmManage = gameManager.GetComponent<PlayerManager>();
        rotAnim = GetComponent<Animator>();
    }


    public void RotateClock()
    {
        hasrot = pmManage.hasrot;
        if (!hasrot)
        {
            print("rotating");
            //transform.Rotate(0, 90, 0);
            rotAnim.SetTrigger("TurnClockWise");
            pmManage.hasrot = true;
        }
        else if (hasrot)
        {
            print("rotating the other way");
            //transform.Rotate(0, -90, 0);
            rotAnim.SetTrigger("TurnAntiClock");
            pmManage.hasrot = false;
        }
    }

    public void RotateAntiClock()
    {
        hasrot = pmManage.hasrot;
        if (!hasrot)
        {
            transform.Rotate(0, -90, 0);
            pmManage.hasrot = true;
        }
        else if (hasrot)
        {
            transform.Rotate(0, 90, 0);
            pmManage.hasrot = false;
        }
    }
}
