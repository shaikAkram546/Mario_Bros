using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D myBody;
    private int jumpCount=0;
    private bool jumpLeft = true, animationFinished, animationStarted, canMove = true;
    private string coroutine_name = "jumpFrog";
    //public Transform up_position;
    public LayerMask playerLayer;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        StartCoroutine(coroutine_name);
    }
    private void Update()
    {
       // killfrog();
    }

    void LateUpdate()
    {
        if (animationFinished && animationStarted)
        {
            //print("called");
            animationStarted = false;
            transform.parent.position = transform.position;
            transform.localPosition = Vector3.zero;
        }
    }
  
    IEnumerator jumpFrog()
    {
        if (canMove)
        {
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            animationFinished = false;
            animationStarted = true;
            jumpCount++;
            if (jumpLeft)
            {
                anim.Play("frogjumpleft");
            }
            else
            {
                anim.Play("frogjumpright");
            }
            StartCoroutine(coroutine_name);
        }

    }
    void animationCheck()
    {
        animationFinished = true;
        if (jumpLeft)
        {
            anim.Play("frogleftidle");
        }
        else
        {
            anim.Play("frogrightidle");
        }
        if (jumpCount == 3)
        {
            print("called");
            jumpCount = 0;
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
            jumpLeft = !jumpLeft;
        }
    }
 
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == Tags.bomb_tag)
        {
            
            //frog damage...
        }

    }

}
