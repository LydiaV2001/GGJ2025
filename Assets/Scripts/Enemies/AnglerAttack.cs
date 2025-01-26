using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnglerAttack : MonoBehaviour
{
    private static readonly int attacking = Animator.StringToHash("isAttacking");

    public float puffUpInterval = 0.85f;
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
            animator.SetBool(attacking, false);
            hitbox.SetActive(false);
            timer = 0f;
        }
        else if (timer >= puffUpInterval)
        {
            animator.SetBool(attacking, true);
            hitbox.SetActive(true);
        }
        
    }
}

