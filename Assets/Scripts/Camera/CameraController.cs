using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerMovement player;
    
    private CinemachineVirtualCamera vcam;
    private CinemachineComponentBase componentBase;
    // Start is called before the first frame update
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        componentBase = vcam.GetCinemachineComponent<CinemachineComponentBase>();
        
        // Add Event Listeners
        player.onJumpingEvent.AddListener(PlayerJump);
        player.onLandEvent.AddListener(PlayerLand);
    }

    private void PlayerJump()
    {
        if (componentBase is CinemachineFramingTransposer) {
            var framingTransposer = componentBase as CinemachineFramingTransposer;
            framingTransposer.m_DeadZoneHeight = 1f;
        }
    }

    private void PlayerLand()
    {
        if (componentBase is CinemachineFramingTransposer) {
            var framingTransposer = componentBase as CinemachineFramingTransposer;
            framingTransposer.m_DeadZoneHeight = 0f;
        }
    }
}
