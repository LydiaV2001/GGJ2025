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

        public bool dead = false;

        Transform bubbleTransform;
        public GameObject gameOverUI;
        
        void Start()
        {
            Time.timeScale = 1f;
            currentHealth = startingHealth;
            bubbleTransform = GameObject.Find("Bubble").transform;
        }

        void Update()
        {
            if (currentHealth > 0)
            {
                currentHealth -= healthDecayRate * Time.deltaTime;
                scaleBubble();
            }
            else
            {
                dead = true;
                bubbleTransform.localScale = new Vector3(0, 0, 1);
                gameOverUI.SetActive(true);
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

        void scaleBubble(){
            // Linear equation, bubble will be 0.8 scale at 0 health, 2 at max health
            float scale = 0.8f + (1.2f/maxHealth * currentHealth);
            bubbleTransform.localScale = new Vector3(scale, scale, 1);
        }
    }
}
