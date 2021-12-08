using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsRightPlace : MonoBehaviour
{
    GameObject waterColl;

    string obName;


    void OnTriggerEnter(Collider obColl)
    {
        obName = transform.name;
        print(obName);
        waterColl = GameObject.Find(obName);
    }   
}
