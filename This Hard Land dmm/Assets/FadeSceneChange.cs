using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSceneChange : MonoBehaviour  //THis script contains a method, triggered by the UI face animation. This script works in tandem with the "ChangeSceneCollider" script
{                                             // Which will change to the appropraite scene
    GameObject changeCol;
    ChangeSceneCollider changeSceneScript;

    // Start is called before the first frame update
    void Start()
    {
        changeCol = GameObject.Find("ChangeSceneCollider");
        changeSceneScript = changeCol.GetComponent<ChangeSceneCollider>();
    }

    void ChangeScene()
    {
        changeSceneScript.LoadCorrectScene();
    }

}
