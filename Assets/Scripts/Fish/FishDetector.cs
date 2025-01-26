using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDetector : MonoBehaviour
{
    GameObject Fish;
    GameObject FishTrigger;
    Collider2D fish;
    Collider2D fishTrigger;
    public bool canPickUpFish;
    
    // Start is called before the first frame update
    void Start()
    {
        Fish = GameObject.Find("fish");
        FishTrigger = GameObject.Find("FishTrigger");

        canPickUpFish = false;
    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("fish")){
            canPickUpFish = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("fish")){
            canPickUpFish = false;
        }
    }
}
