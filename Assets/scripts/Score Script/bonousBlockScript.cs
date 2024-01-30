using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bonousBlockScript : MonoBehaviour
{
    private Animator anim;
    private bool canAnimate;
    public LayerMask playerLayer;
    public Transform blockChild;
    private static int blockScore;//using static is important in this code, otherwise the value of the blockScire will not increases all the time..
    public Text blockScoreText;
    public bool hit;
    

    void Start()
    {
         
        anim = GetComponent<Animator>();
        canAnimate = true;
    }

    private void Update()
    {
       
        detect(); // Call the detect method to perform collision detection
        playIdle();

    }

    void detect()
    {
         hit = Physics2D.Raycast(blockChild.position, Vector2.down, 0.1f, playerLayer);
        if (hit)
        {
            
            if (canAnimate)
                {
                 
                   //print("called");
                 
                  //print("called"+ blockScore);
                    blockScoreText.text = "X Bonus : " + (blockScore+=5).ToString();
                     GameObject.FindGameObjectWithTag(Tags.player_tag).GetComponent<playerWalk>().playBonousSound();//Getting reference of player by using tags...
                    canAnimate = false;
                    playIdle();
                }
            
        }
    }
    void playIdle()
    {
        if (!canAnimate)
        {
            anim.Play("blockidle");
        }
    }
}
