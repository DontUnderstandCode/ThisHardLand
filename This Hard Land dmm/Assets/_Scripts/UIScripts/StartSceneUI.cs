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

    public void LoadScene()
    {
    SceneManager.LoadScene("002IntroScene", LoadSceneMode.Single);
    }

    public void StartGame()
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
