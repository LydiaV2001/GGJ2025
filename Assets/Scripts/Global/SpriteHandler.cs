using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpriteHandler
{
    public static void flipSprite(Rigidbody2D rb, SpriteRenderer spriteRenderer){
        if(rb.velocity.x < 0){
            spriteRenderer.flipX = true;
        }else{
            spriteRenderer.flipX = false;
        }
    }

}
