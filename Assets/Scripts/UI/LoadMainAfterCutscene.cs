using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class LoadMainAfterCutscene : MonoBehaviour
{

    public PlayableDirector timeline;
    void Start(){
        Time.timeScale = 1;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Return)){
            loadMain();
        }
    }

    public void loadMain(){
        SceneManager.LoadScene("Main");
    }
    
}
