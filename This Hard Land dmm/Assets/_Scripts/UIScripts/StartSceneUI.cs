using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneUI : MonoBehaviour   //This script holds the method that loads the main puzzle scene on reaching the end of the scene
{
    GameObject fadeUI;
    Animator fadeUIAnim;

    public void LoadScene()
    {
    SceneManager.LoadScene("002IntroScene", LoadSceneMode.Single);
    }

    public void StartGame()
    {
        fadeUIAnim.SetTrigger("fadeClose");
    }

    public void QuitGame()
    {
        fadeUIAnim.SetTrigger("fadeQuit");
    }


    //public void Application


}
