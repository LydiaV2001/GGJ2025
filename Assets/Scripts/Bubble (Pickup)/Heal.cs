using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Heal : MonoBehaviour
{

    public float healAmmount;
    PlayerHealth playerHealth;
    
    public new Collider2D collider2D;

    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HealPlayer();
        }
    }

    void HealPlayer()
    {
        if (playerHealth != null)
        {
            playerHealth.IncreaseHealth(healAmmount);
            Destroy(gameObject);
        }
    }
    
}
