using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    public GameObject escMenuObject;
    bool isPaused;
    bool rPresed;
    GameObject oarfishImageObject;
    Image oarfishImage;
   

    void Start(){
        isPaused = false;
        rPresed = false;
        oarfishImageObject = escMenuObject.transform.Find("oarfishImage").gameObject;
        oarfishImage = oarfishImageObject.GetComponent<Image>();
    }


    void Update(){
        pressEsc();
        if(Input.GetKeyDown("r")){
            rPresed = true;
            Debug.Log("R!!");
        }
        updateFishCollection();
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


    void updateFishCollection(){
        if(rPresed){
            oarfishImage.color = Color.red;
        }
    }
}
