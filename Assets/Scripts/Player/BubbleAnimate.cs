using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleAnimate : MonoBehaviour
{
    
    private Animator animator;
    private ParticleSystem particleSystem;
    
    public PlayerMovement playerMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        // get animator
        animator = GetComponent<Animator>();
        particleSystem = GetComponent<ParticleSystem>();
        
        
        playerMovement.onSlamEvent.AddListener(AnimateBounce);
    }

    // Update is called once per frame
    void AnimateBounce()
    {
        particleSystem.Play();
        animator.ResetTrigger("bounce");
        animator.SetTrigger("bounce");
    }
}
