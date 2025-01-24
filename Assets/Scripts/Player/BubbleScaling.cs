using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class BubbleScaling : MonoBehaviour
{
    public SpriteRenderer bubbleSprite;
    public GameObject bubbleObject;
    
    public float BubbleScale = 5;

    private PlayerHealth _playerHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        //bubbleSprite.size = new Vector2((_playerHealth.currentHealth / _playerHealth.maxHealth) * BubbleScale, (_playerHealth.currentHealth / _playerHealth.maxHealth) * BubbleScale);
        
        bubbleObject.transform.localScale = new Vector2((_playerHealth.currentHealth / _playerHealth.maxHealth) * BubbleScale, (_playerHealth.currentHealth / _playerHealth.maxHealth) * BubbleScale);
    }
}
