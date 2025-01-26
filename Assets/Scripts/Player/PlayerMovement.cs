using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxSpeed = 0.0001f;
    public Vector2 slamSpeed = new Vector2(0.001f, -0.002f);
    public float groundAcc = 4f;
    public float airAcc = .5f;
    float horizontalSpeed = 1f;
    float verticalSpeed = 1f;
    
    float acc = 4f;

    public GameObject dustPrefab;
    public GameObject bubbleTrailPrefab;
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
    
    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(rb == null){
            Debug.LogError("Player is missing the rigidbody");
        }

        if(spriteRenderer == null){
            Debug.LogError("Sprite Renderer not found!");
        }
    }

    void FixedUpdate(){
        handleMovement();
    }

    void Update(){
        jumpHandler();
        slamHandler();
        flipSprite();
    }

    void OnCollisionEnter2D(Collision2D collider){
        bounce(collider);
    }

    void slamHandler(){
        if(Input.GetKeyDown(KeyCode.LeftShift) && !grounded && !slam){
            onSlamEvent.Invoke();
            slam = true;
            rb.sharedMaterial = bounceMaterial;

            Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), rb.velocity.y);
            Vector2 target = new Vector2(direction.x*slamSpeed.x, slamSpeed.y);
            rb.velocity = Vector2.Lerp(rb.velocity, target, 0.5f);
            if (bubbleTrailPrefab != null) {
                Instantiate(bubbleTrailPrefab, transform);
            }
        }
    }

    void bounce(Collision2D collider){
        if(collider.gameObject.layer == LayerMask.NameToLayer("Platform") && slam == true){
            slam = false;
            rb.sharedMaterial = defaultMaterial;
            horizontalSpeed = 1.4f;
            Invoke("resetHorizontalSpeed", 0.5f);
        }
    }


    void jumpHandler(){
        // If player can jump
        if(Input.GetKeyDown("space") || jumpBuffered){
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
                acc = groundAcc;
                grounded = true;
            }
            
        } else {
            if (grounded) {
                onJumpingEvent.Invoke();
                Invoke("groundPlayer", 0.15f);
                acc = airAcc;
            }
        }
    }

    void handleMovement(){
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), rb.velocity.y);
        float targetX = maxSpeed * direction.x;
        targetX = Mathf.Lerp(rb.velocity.x, targetX, acc*Time.deltaTime);
        rb.velocity = new Vector2(targetX, rb.velocity.y);
    }
    
    void restoreBounce(){
        rb.sharedMaterial = bounceMaterial;
    }

    void resetHorizontalSpeed(){
        horizontalSpeed = 1f;
    }

    void flipSprite(){
        // It uses else if because otherwise sprite flips when idle
        if(rb.velocity.x < 0){
            spriteRenderer.flipX = true;
        }else if(rb.velocity.x > 0){
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
