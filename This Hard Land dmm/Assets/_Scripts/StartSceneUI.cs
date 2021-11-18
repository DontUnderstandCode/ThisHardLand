using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadMain()
    {
        SceneManager.LoadScene("003TestScene", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
