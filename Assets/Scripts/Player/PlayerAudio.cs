using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private PlayerMovement playerMovement;

    public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip slamClip;
    
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        
        playerMovement.onSlamEvent.AddListener(PlayBounceAudio);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayJumpAudio()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    void PlayBounceAudio()
    {
        audioSource.PlayOneShot(slamClip);
    }
}
