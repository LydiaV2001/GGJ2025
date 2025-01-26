using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class OpeningMenu : MonoBehaviour
{
    public TextMeshProUGUI jumpButtonText;
    public TextMeshProUGUI bounceButtonText;
    public void onClickPLay(){
        SceneManager.LoadScene("Main");
    }


    public void onClickQuit(){
        Application.Quit();
    }
    

    public void onClickTutorialButton(){
        SceneManager.LoadScene("Tutorial");
    }



    public void onClickJumpButton(){
        StartCoroutine(WaitForKeyInput1());
    }


    public void onClickBounceButton(){
        StartCoroutine(WaitForKeyInput2());
    }

    IEnumerator WaitForKeyInput1(){
        
        jumpButtonText.text = " Press any key to set key";
        KeyCode newKey = KeyCode.None;
        bool keyPressed = false;
        
        while(!keyPressed){
            if(Input.anyKeyDown){
                foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(kcode))
                    {
                        newKey = kcode;
                        keyPressed = true;
                        break;
                    }
                }
            }
            yield return null;
        }
        PlayerMovement.jumpKey = newKey;

        jumpButtonText.text = newKey.ToString();
    }

    IEnumerator WaitForKeyInput2(){
        
        bounceButtonText.text = " Press any key to set key";
        KeyCode newKey = KeyCode.None;
        bool keyPressed = false;
        
        while(!keyPressed){
            if(Input.anyKeyDown){
                foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(kcode))
                    {
                        newKey = kcode;
                        keyPressed = true;
                        break;
                    }
                }
            }
            yield return null;
        }
        PlayerMovement.bounceKey = newKey;

        bounceButtonText.text = newKey.ToString();
    }

}
