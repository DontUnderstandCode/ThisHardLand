using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneUI : MonoBehaviour   //This script holds methods related to starting and quitting the game from the main menu UI
{
    GameObject menuFade;
    Animator menuFadeAnim;

    private void Start()
    {
        menuFade = GameObject.Find("MenuSceneFade");
        menuFadeAnim = menuFade.GetComponent<Animator>();
    }

    public void LoadScene()     //Called by an animation event, checks current scene and moves to the correct scene depending 
    {
        Scene activeScene = SceneManager.GetActiveScene();
        string actvSceneName = activeScene.name;

        if (actvSceneName == "001MenuScene")
        {
            SceneManager.LoadScene("002IntroScene", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("001MenuScene", LoadSceneMode.Single);
        }
    }

    public void MoveScene()
    {
        menuFadeAnim.SetTrigger("menuFadeClose");
    }

    public void QuitGameFade()
    {
        menuFadeAnim.SetTrigger("fadeQuit");
    }

    public void QuitGame()
    {
        Application.Quit();
    }



    


    //public void Application


}
