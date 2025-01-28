using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Player;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 4f;
    public float horizontalSpeed = 1f;
    public float slamForce = 1000f;
    public float speedBonusOnSlam = 1.8f;

    public GameObject dustPrefab;
    public GameObject bubbleTrailPrefab;
    public AudioSource slamSound; 
    public Transform particleSpawnPoint;
    public PhysicsMaterial2D bounceMaterial;
    public PhysicsMaterial2D defaultMaterial;
    private SpriteRenderer spriteRenderer;
    bool grounded = true;
    bool slam = false;
    bool jumpBuffered = false;


    public int jumpHeight = 1000;
    public LayerMask platformLayer;
    
    // unity events
    // i added these here for my ease - Lydia
    public UnityEvent onLandEvent;
    public UnityEvent onSlamEvent;
    public UnityEvent onJumpingEvent;

    //key binding practices.
    public static KeyCode jumpKey = KeyCode.Space;
    public static KeyCode bounceKey = KeyCode.LeftShift;

    PlayerHealth playerHealth;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerHealth = gameObject.GetComponent<PlayerHealth>();

        if(rb == null){
            Debug.LogError("Player is missing the rigidbody");
        }

        if(spriteRenderer == null){
            Debug.LogError("Sprite Renderer not found!");
        }
    }

    void FixedUpdate(){
        if(playerHealth.dead){
            rb.velocity = new Vector2(0, 0);
            return;
        }

        handleMovement();
    }

    void Update(){

        if(playerHealth.dead){
            return;
        }

        jumpHandler();
        slamHandler();
        flipSprite();
    }

    void OnCollisionEnter2D(Collision2D collider){
        bounce(collider);
    }

    void slamHandler(){
        if(Input.GetKeyDown(bounceKey) && !grounded && !slam){
            onSlamEvent.Invoke();
            slam = true;
            rb.sharedMaterial = bounceMaterial;

            rb.AddForce(new Vector2(0, -slamForce));


            if (bubbleTrailPrefab != null) {
                Instantiate(bubbleTrailPrefab, transform);
            }

            slamSound.Play();
        }
    }

    void bounce(Collision2D collider){
        if(collider.gameObject.layer == LayerMask.NameToLayer("Platform") && slam == true){
            slam = false;
            rb.sharedMaterial = defaultMaterial;
            horizontalSpeed = speedBonusOnSlam;
            Invoke("resetHorizontalSpeed", 0.5f);
        }
    }


    void jumpHandler(){
        // If player can jump
        if(Input.GetKeyDown(jumpKey) || jumpBuffered){
            if (grounded) {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(new Vector2(0,jumpHeight));
                jumpBuffered = false;
                grounded = false;
            }
            else {
                Invoke("debufferJump", 0.2f);
                jumpBuffered = true;
            }
        }

        Vector3 checkOffset = new Vector3(0.45f, 0f, 0f);
        float checkLength = .9f;
        RaycastHit2D floorCheckL = Physics2D.Raycast(transform.position + checkOffset, Vector2.down, checkLength, platformLayer);
        RaycastHit2D floorCheckR = Physics2D.Raycast(transform.position - checkOffset, Vector2.down, checkLength, platformLayer);

        // Check for ground below player 
        if(floorCheckL.collider != null || floorCheckR.collider != null){
            onLandEvent.Invoke();
            if (!grounded) {
                // Spawn Particles
                if (dustPrefab != null && particleSpawnPoint != null) {
                    Instantiate(dustPrefab, particleSpawnPoint.position, Quaternion.identity);
                }
                grounded = true;
            }
            
        } else {
            if (grounded) {
                onJumpingEvent.Invoke();
                Invoke("groundPlayer", 0.15f);
            }
        }
    }

    void handleMovement(){
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal") * speed * horizontalSpeed, rb.velocity.y);
        rb.velocity = direction;
    }
    
    void restoreBounce(){
        rb.sharedMaterial = bounceMaterial;
    }

    void resetHorizontalSpeed(){
        horizontalSpeed = 1f;
    }

    void flipSprite(){
        // It uses else if because otherwise sprite flips when idle
        if(rb.velocity.x < -0.1){
            spriteRenderer.flipX = true;
        }else if(rb.velocity.x > 0.1){
            spriteRenderer.flipX = false;
        }
    }
    void groundPlayer() {
        grounded = false;
    }
    void debufferJump() {
        jumpBuffered = false;
    }

}
