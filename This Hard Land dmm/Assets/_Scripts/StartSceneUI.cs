using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneUI : MonoBehaviour   //This script holds the method that loads the main puzzle scene on reaching the end of the scene
{


    public void LoadMain()
    {
        SceneManager.LoadScene("002IntroScene", LoadSceneMode.Single);
    }


}
