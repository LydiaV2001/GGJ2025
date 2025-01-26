using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglerAttack : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){

    }

    void detectPlayer(){
        float rayDistance = 4f;
    }


}
