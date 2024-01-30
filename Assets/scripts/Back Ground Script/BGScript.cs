using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScript : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(1, 1, 1);
        float width = sr.sprite.bounds.size.x; // this is to calculate the  width size of sprite 
        float height = sr.sprite.bounds.size.y;// this is to calculate the height of the sprite 

        float worldHeight = Camera.main.orthographicSize*2f; // this is formula to calculate the world height.
        float worldWidth = worldHeight / Screen.width * Screen.height;  // This is the formula to calculate the world width 

        Vector3 temp = transform.localScale;
        temp.x = worldWidth / width + 0.1f; // this will fix the size of sprite with camera size.
        temp.y = worldHeight / height + 0.1f;
        transform.localScale = temp;
   
    }
}
