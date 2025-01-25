using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{
    public GameObject escMenu;
    bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            pullTheMenu();
        }
    }
    void onEscapePause(){
        Time.timeScale = 0;
        isPaused = true;
        escMenu.SetActive(true);
    }
    void onEscapeResume(){
        Time.timeScale = 1;
        isPaused = false;
        escMenu.SetActive(false);
    }
    void pullTheMenu(){
        if(isPaused){
            onEscapeResume();
        }
        else{
            onEscapePause();
        }
    }


}
