using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDefault : MonoBehaviour
{
    public float speed;
    public FishData data;

    //These must me empty objects attatched to the enemy
    Transform pointA;
    Transform pointB;
    Transform currentDestination;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    public bool isUrchin = false;

    // Start is called before the first frame update
    void Start()
    {
        //Components
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();


        if(isUrchin == false){
            Transform parent = gameObject.transform.parent;
            pointA = parent.Find("PointA");
            pointB = parent.Find("PointB");

            if(pointA == null || pointB == null){
                Debug.LogError("Enemy is missing destination points");
            }

            currentDestination = pointA;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementHandler();
        SpriteHandler.flipSprite(rb, spriteRenderer);
    }

    void movementHandler(){
        // Don't move if it's a sea urchin
        if(isUrchin){
            return;
        }

        Vector2 direction = currentDestination.position - transform.position;
        rb.velocity = direction.normalized * speed;

        if(Vector2.Distance(currentDestination.position, transform.position) < 0.5){            
            // If we are at point A, go to B
            if(currentDestination.position == pointA.position){
                currentDestination = pointB;
            }else{
                // If a B, go to A
                currentDestination = pointA;
            }
        }
    }
}
