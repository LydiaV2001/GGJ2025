using System;
using System.Collections;
using UnityEngine;


namespace Enemies
{
    public class SwordFish : MonoBehaviour
    {

        public Transform swordFish;
        public float dashSpeed;
        
        private new Rigidbody2D rigidbody2D;
        private SpriteRenderer spriteRenderer;
        private Transform player;
        private Vector2 direction;
        private bool isDashing = false;
        
        private void Start()
        {
            rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GetComponent<FishDefault>().enabled = false;
                rigidbody2D.velocity = Vector2.zero;
            }
            
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {

                if (!isDashing)
                {
                    StartCoroutine(Charge());
                    
                    player = GameObject.Find("Player").transform;

                    direction = player.position - transform.position;
                
                    if (player.position.x < transform.position.x)
                    {
                        spriteRenderer.flipY = true;
                        spriteRenderer.flipX = false;
                    }
                    else
                    {
                        spriteRenderer.flipY = false;
                        spriteRenderer.flipX = false;
                    }
                
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                    if (angle > 180)
                    {
                        angle = 180 - angle;
                    }
                
                    transform.rotation = Quaternion.Euler(0, 0, angle);
                    
                }

            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GetComponent<FishDefault>().enabled = true;
            }
        }

        IEnumerator Charge()
        {
            yield return new WaitForSeconds(1f);
            DashAtPlayer();
        }

        IEnumerator StopDash()
        {
            yield return new WaitForSeconds(1f);
            rigidbody2D.velocity = Vector2.zero;
            isDashing = false;
        }
        
        private void DashAtPlayer()
        {
            rigidbody2D.velocity = direction.normalized * dashSpeed;
            isDashing = true;
            StartCoroutine(StopDash());
        }
        
    }
}
