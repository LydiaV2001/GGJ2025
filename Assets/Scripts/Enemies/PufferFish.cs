using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PufferFish : MonoBehaviour
{
    
    public float puffUpInterval = 2f;
    public float puffDownInterval = 2f;
    public GameObject hitbox;
    
    private float timer;

    private void Start()
    {
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
            hitbox.SetActive(false);
            timer = 0f;
        }
        else if (timer >= puffUpInterval)
        {
            hitbox.SetActive(true);
        }
        
    }
}
