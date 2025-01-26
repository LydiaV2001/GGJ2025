using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    public GameObject escMenuObject;
    bool isPaused;
   

    void Start(){
        isPaused = false;
    }


    void Update(){
        pressEsc();
    }


    void closeTheMenu(){
        Time.timeScale = 1;
        isPaused = false;
        escMenuObject.SetActive(false);
    }


    void openTheMenu(){
        Time.timeScale = 0;
        isPaused = true;
        escMenuObject.SetActive(true);
    }


    void pressEsc(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                closeTheMenu();
            }
            else{
                openTheMenu();
            }
        }
    }

    public void onClickResume(){
        Time.timeScale = 1;
        isPaused = false;
        escMenuObject.SetActive(false);
    }


    public void onClickExit(){
        Time.timeScale = 1;
        isPaused = false;
        SceneManager.LoadScene("libertes scene(opening)");
    }


}
