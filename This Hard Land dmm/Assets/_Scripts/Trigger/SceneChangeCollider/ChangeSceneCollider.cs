using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneCollider : MonoBehaviour  //This script detects a trigger entry, checks the scene name and puzzle status and then loads the correct scene.
{                                                 //This script works in tandem with the UI script "FadeSceneChange"
    GameObject gameManager;
    ObstacleManager obManage;

    GameObject fadeUI;
    Animator fadeUIAnim;  //This is the fade UI parent object and it's associated animator.

    string actvSceneName;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        obManage = gameManager.GetComponent<ObstacleManager>();

        fadeUI = GameObject.Find("FadeUIParent");
        fadeUIAnim = fadeUI.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider loadScene)     //Triggered when the player walks into the object:" ChangeSceneCollider"
    {
        if(loadScene.gameObject.name == "Player")  //First filters out the collisions to check its the player
        {           
            CheckScene();
        }
    }

    void CheckScene()              //Gets the active scene and fills a string with it's name
    {
        Scene activeScene = SceneManager.GetActiveScene();
        actvSceneName = activeScene.name;

        StartFadeAnim();   

    }

    void StartFadeAnim()   //THis method triggers an animation on the Fade UI object, and in tirn an animation event triggers the method below
    {
        fadeUIAnim.SetTrigger("fadeClose");
    }

    public void LoadCorrectScene()      //Checks that name,and the puzzle completion status from the obstacle manager, to load the correct scene. Triggered by an animation event 
                                        //on the fade Images.
    
    {
        if(actvSceneName == "003PuzzleScene" && obManage.puzzleComplete)  //If puzzle is complete, goes to the final scene
        {
            SceneManager.LoadScene("005FinalScene", LoadSceneMode.Single);
        }
        else if(actvSceneName == "003PuzzleScene" && !obManage.puzzleComplete)
        {
            SceneManager.LoadScene("004IntroSceneVer2", LoadSceneMode.Single);
        }
        else if(actvSceneName == "002IntroScene")
        {
            SceneManager.LoadScene("003PuzzleScene", LoadSceneMode.Single);
        }
        else if(actvSceneName == "004IntroSceneVer2")
        {
            SceneManager.LoadScene("003PuzzleScene", LoadSceneMode.Single);
        }

    }


}
