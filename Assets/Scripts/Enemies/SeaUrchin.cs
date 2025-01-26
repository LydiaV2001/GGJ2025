using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class SeaUrchin : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collider){
        collider.gameObject.GetComponent<PlayerHealth>().DecreaseHealth(100);
    }
}
