using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OpeningMenu : MonoBehaviour
{
    public GameObject OptionBoxPanel;
    
    public void onClickPLay(){
        SceneManager.LoadScene("Libertes Main");
    }

    public void onClickQuit(){
        Application.Quit();
    }

    public void onClickOptions(){
        OptionBoxPanel.SetActive(true);
    }

    //option box button
    public void onClickCloseOptionPanel(){
        OptionBoxPanel.SetActive(false);
    }

}
