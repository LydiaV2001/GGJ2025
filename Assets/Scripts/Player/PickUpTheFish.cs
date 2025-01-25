using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTheFish : MonoBehaviour
{
    public GameObject youFoundAFish;
    bool isPaused;
    FishDetector fishDetector;
    
    // Start is called before the first frame update
    
    public void Start(){
        GameObject FishTriggerObject = GameObject.Find("FishTrigger");
        fishDetector = FishTriggerObject.GetComponent<FishDetector>();
    }
    public void Update(){
        if(fishDetector.canPickUpFish){
            if(Input.GetKeyDown("e")){
                pickUp();
            }
        }
    }
    public void onPickUpPause(){
        Time.timeScale = 0;
        isPaused = true;
        Debug.Log("paused");
        youFoundAFish.SetActive(true);
    }
    public void onPickUpResume(){
        Time.timeScale = 1;
        isPaused = false;
        Debug.Log("resumed");
        youFoundAFish.SetActive(false);
    }
    public void pickUp(){
        if(isPaused){
            onPickUpResume();
        }
        else{
            onPickUpPause();
        }
        
    }
}
