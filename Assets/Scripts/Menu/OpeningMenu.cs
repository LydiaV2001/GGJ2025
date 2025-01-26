using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OpeningMenu : MonoBehaviour
{
    
    public void onClickPLay(){
        SceneManager.LoadScene("Main");
    }

    public void onClickQuit(){
        Application.Quit();
    }

    public void onClickTutorialButton(){
        Debug.Log("Loaded tutorial scene");
    }

    

}
