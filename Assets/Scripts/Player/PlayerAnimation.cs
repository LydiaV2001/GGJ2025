using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator animator;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpAnimation();
    }

    void jumpAnimation(){
        if(rb.velocity.y > 0.01){
            animator.SetBool("jumping", true);
        }else{
            animator.SetBool("jumping", false);
        }

        if(rb.velocity.y < -0.01){
            animator.SetBool("falling", true);
        }else{
            animator.SetBool("falling", false);
        }
    }
}
