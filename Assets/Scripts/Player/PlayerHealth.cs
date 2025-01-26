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

        Transform bubbleTransform;
        
        void Start()
        {
            currentHealth = startingHealth;
            bubbleTransform = GameObject.Find("Bubble").transform;
        }

        void Update()
        {
            if (currentHealth > 0)
            {
                currentHealth -= healthDecayRate * Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            scaleBubble();
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

        void scaleBubble(){
            // Linear equation, bubble will be 0.8 scale at 0 health, 2 at max health
            float scale = 0.8f + (1.2f/maxHealth * currentHealth);
            bubbleTransform.localScale = new Vector3(scale, scale, 1);
        }
    }
}
