using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Leaderboard : MonoBehaviour
{

    public Transform fastestTransform;
    public Transform completionTransform;
    
    private List<LeaderboardData> anyLeaderboard;
    
    // private List<LeaderboardData> completeLeaderboard;
    
    private string userInput;
    
    public TMP_InputField inputField;

    private void Start()
    {
        
    }

    private void GetPlayerInput()
    {
        userInput = inputField.text;
    }

    private void GetPlayerTime()
    {
        
    }
    
    private void UpdateLeaderboard()
    {
        foreach (Transform child in fastestTransform)
        {
            
        }
    }

    public void OnButtonPressed()
    {
        GetPlayerInput();
        
    }
    
}
