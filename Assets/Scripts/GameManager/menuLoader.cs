using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class menuLoader : MonoBehaviour
{
    public void onClickMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void onClickMainGame(){
        SceneManager.LoadScene("Main");
    }
}
