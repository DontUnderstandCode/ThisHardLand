using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsRightPlace : MonoBehaviour
{
    GameObject obParent;

    string obName;

    void OnTriggerEnter(Collider obColl)
    {
        obName = obColl.gameObject.name;
        obParent = GameObject.Find(obName);
        print(obParent.name);
    }   
}
