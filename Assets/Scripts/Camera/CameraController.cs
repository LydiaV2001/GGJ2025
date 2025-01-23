using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerMovement player;
    
    CinemachineVirtualCamera vcam;
    // Start is called before the first frame update
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        
        player.onLandEvent.AddListener(JumpToPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void JumpToPlayer()
    {
        Debug.Log("JumpToPlayer");
    }
}
