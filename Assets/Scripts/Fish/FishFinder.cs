using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishFinder : MonoBehaviour
{
    GameObject currentFish;
    
    // Set this to the ui background that the fish image will be on
    public GameObject fishImageBackground;

    bool clipboardIsOpen = false;

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Fish"){
            currentFish = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Fish"){
            currentFish = null;
        }
    }

    void Update(){
        if(clipboardIsOpen){
            closeClipboard();
        }else{
            openClipboard();
        }

    }

    void closeClipboard(){
        if(clipboardIsOpen){
            if(Input.GetKeyDown("e")){
                fishImageBackground.SetActive(false);
                clipboardIsOpen = false;
                Time.timeScale = 1;
            }
        }
    }

    void openClipboard(){
        if(Input.GetKeyDown("e") && currentFish != null){
            // Freeze time
            Time.timeScale = 0;
            clipboardIsOpen = true;

            //Open UI to show fish info
            FishDefault fishScript = currentFish.GetComponent<FishDefault>();
            string description = fishScript.data.description;
            Texture2D fishPicture = fishScript.data.image;

            fishImageBackground.SetActive(true);
            Image fishImageComponent = fishImageBackground.GetComponent<Image>();

            if (fishImageComponent != null && fishPicture != null)
            {
                // Convert Texture2D to Sprite
                Rect rect = new Rect(0, 0, fishPicture.width, fishPicture.height);
                Vector2 pivot = new Vector2(0.5f, 0.5f); // Center pivot
                Sprite fishSprite = Sprite.Create(fishPicture, rect, pivot);

                // Set the Image component's sprite
                fishImageComponent.sprite = fishSprite;
            }

        }
    }
}
