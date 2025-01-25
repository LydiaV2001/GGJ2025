using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damageAmmount;
    PlayerHealth playerHealth;
    
    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DamagePlayer();
        }
    }

    void DamagePlayer()
    {
        if (playerHealth != null)
        {
            playerHealth.DecreaseHealth(damageAmmount);
        }
        
    }
}
