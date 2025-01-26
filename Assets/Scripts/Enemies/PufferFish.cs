using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PufferFish : MonoBehaviour
{
    private static readonly int PuffedUp = Animator.StringToHash("puffedUp");

    public float puffUpInterval = 2f;
    public float puffDownInterval = 2f;
    public GameObject hitbox;
    
    private float timer;
    private Animator animator;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        hitbox.SetActive(false);
    }

    void Update()
    {
       PuffUp();
    }

    void PuffUp()
    {
        timer += Time.deltaTime;

        if (timer >= puffUpInterval + puffDownInterval)
        {
            animator.SetBool(PuffedUp, false);
            hitbox.SetActive(false);
            timer = 0f;
        }
        else if (timer >= puffUpInterval)
        {
            animator.SetBool(PuffedUp, true);
            hitbox.SetActive(true);
        }
        
    }
}
