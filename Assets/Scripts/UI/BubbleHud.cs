using System;
using Player;
using TMPro;
using UnityEngine;

namespace UI
{
    public class BubbleHud : MonoBehaviour
    {
        // show HUD
        public bool showHud = true;
        
        // hud element
        public TMP_Text bubbleText;
        public Vector2 screenPoint;
        [SerializeField] private int offset = 32;
        
        // player
        public GameObject player;
        public PlayerHealth playerHealth;

        private void Start()
        {
            if (!showHud)
            {
                Destroy(this.gameObject);
            }
        }

        private void Update()
        {
            // get screenpoint of player object
            screenPoint = Camera.main.WorldToScreenPoint(player.transform.position);

            screenPoint = new Vector2(screenPoint.x, screenPoint.y + offset);

            // set screenpoint to hud element
            bubbleText.transform.position = screenPoint;
            bubbleText.text = playerHealth.currentHealth.ToString();
        }
    }
}