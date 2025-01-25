using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTheFish : MonoBehaviour
{
    public GameObject youFoundAFish;
    bool isPaused;
    FishDetector fishDetector;
    
    // Start is called before the first frame update
    
    void Start(){
        GameObject FishTriggerObject = GameObject.Find("FishTrigger");
        fishDetector = FishTriggerObject.GetComponent<FishDetector>();
    }
    void Update(){
        if(fishDetector.canPickUpFish){
            if(Input.GetKeyDown("e")){
                pickUp();
            }
        }
    }
    void onPickUpPause(){
        Time.timeScale = 0;
        isPaused = true;
        youFoundAFish.SetActive(true);
    }
    void onPickUpResume(){
        Time.timeScale = 1;
        isPaused = false;
        youFoundAFish.SetActive(false);
    }
    void pickUp(){
        if(isPaused){
            onPickUpResume();
        }
        else{
            onPickUpPause();
        }
        
    }
}
