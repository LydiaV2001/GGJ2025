using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
    
        public float maxHealth;
        public float startingHealth;
        public float healthDecayRate;
        public float currentHealth;
        
        void Start()
        {
            currentHealth = startingHealth;
        }

        void Update()
        {
            if (currentHealth > 0)
            {
                currentHealth -= healthDecayRate * Time.deltaTime;
            }
            else
            {
                transform.position = new Vector3(-4, 4, 0);
                currentHealth = startingHealth;
            }
        }

        public void IncreaseHealth(float amount)
        {
            currentHealth += amount;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            
        }

        public void DecreaseHealth(float amount)
        {
            currentHealth -= amount;
            if (currentHealth < 0)
            {
                currentHealth = 0;
            }
            
        }
    }
}
