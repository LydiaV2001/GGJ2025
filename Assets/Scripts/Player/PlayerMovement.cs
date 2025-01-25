using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    float horizontalSpeed = 1f;
    float verticalSpeed = 1f;


    public PhysicsMaterial2D bounceMaterial;
    public PhysicsMaterial2D defaultMaterial;
    private SpriteRenderer spriteRenderer;
    bool grounded = true;
    bool slam = false;


    public int jumpHeight = 1000;
    public LayerMask platformLayer;

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
            slam = true;
            rb.sharedMaterial = bounceMaterial;
            rb.AddForce(new Vector2(0f,-400f));
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
        if(Input.GetKeyDown("space") && grounded){
            rb.AddForce(new Vector2(0,jumpHeight));
            grounded = false;
        }

        RaycastHit2D floorCheck = Physics2D.Raycast(transform.position, Vector2.down, 1f, platformLayer);

        // Check for ground below player 
        if(floorCheck.collider != null){
            grounded = true;
        }else{
            grounded = false;
        }

    }

    void handleMovement(){
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
        direction.x = direction.x * horizontalSpeed;
        direction.y = direction.y * verticalSpeed;
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
        if(rb.velocity.x < 0){
            spriteRenderer.flipX = true;
        }else if(rb.velocity.x > 0){
            spriteRenderer.flipX = false;
        }
    }

}
