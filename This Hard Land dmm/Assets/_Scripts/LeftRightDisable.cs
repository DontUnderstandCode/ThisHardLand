using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightDisable : MonoBehaviour
{

    GameObject player;
    LeftRightMove leftRight;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        leftRight = player.GetComponent<LeftRightMove>();
    }

    void OnTriggerStay()
    {
        leftRight.enabled = false;
    }

    void OnTriggerExit()
    {
        leftRight.enabled = true;
    }

}
