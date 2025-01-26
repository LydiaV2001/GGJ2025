using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainAfterCutscene : MonoBehaviour
{

    void Update(){
        if(Input.GetKeyDown(KeyCode.Return)){
            loadMain();
        }
    }

    public void loadMain(){
        SceneManager.LoadScene("Main");
    }
    
}
