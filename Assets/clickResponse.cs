using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickResponse : MonoBehaviour
{
    public GameObject youFoundAFish;
    bool isPaused;
    // Start is called before the first frame update
    
    public void Start(){
        
       
    }
    public void Update(){
        
        if(Input.GetKeyDown("e")){
            if(isPaused){
                gameResume();
            }
            else{
                gamePause();
            }
        }
    }
    public void gamePause(){
        Time.timeScale = 0;
        isPaused = true;
        Debug.Log("paused");
        youFoundAFish.SetActive(true);
    }
    public void gameResume(){
        Time.timeScale = 1;
        isPaused = false;
        Debug.Log("resumed");
        youFoundAFish.SetActive(false);
    }
}
