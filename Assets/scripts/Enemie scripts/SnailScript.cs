using System.Collections;
using UnityEngine;

public class SnailScript : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Animator anim;
    public float speed = 0.2f;
    public Transform groundCheck, up_position, left_position, right_position;
    private bool moveLeft, canMove, stun;
    public LayerMask playerLayer;
    private Vector3 originalScale;
    Collider2D leftHit, upHit, rightHit;// This data type is similar as boolean data type.
    

    void Start()
    {
        stun = false;
        moveLeft = true;
        canMove = true;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //originalScale = transform.localScale;
    }

    void Update()
    {
        changeDirection();
        playerMove();
        collision();
        playerDied();
    }

    void playerMove()
    {
        if (canMove)
        {
            float currentSpeed = moveLeft ? -speed : speed; //This is ternerry conditional operator this is similar as if else if moveLeft is true then -speed is assigned to currentspeed else speed is assigned  
            myBody.velocity = new Vector2(currentSpeed, myBody.velocity.y);//This line makes the player move.
           
        }
    }

    void changeDirection()
    {
        if (!Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f))
        {
            Flip();
            //print("happend");
            moveLeft = !moveLeft;
          
        }
    }

    void Flip()
    {
        Vector3 temp1 = transform.localScale;
        temp1.x *= -1f;//changes the direction of the snail
        transform.localScale = temp1;//In this line the direction will changes In the above line the the internal process will happens.

        // Swap left and right positions
        Vector3 temp = left_position.position;
        left_position.position = right_position.position;
        right_position.position = temp;
    } 

    void collision()
    {
         upHit = Physics2D.OverlapCircle(up_position.position, 0.2f, playerLayer);
        leftHit = Physics2D.OverlapCircle(left_position.position, 0.2f, playerLayer);
        rightHit = Physics2D.OverlapCircle(right_position.position, 0.2f, playerLayer);
      
        if (upHit != null && upHit.gameObject.CompareTag("player") )
        {
           
            if (!stun)
            {
                upHit.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(upHit.gameObject.GetComponent<Rigidbody2D>().velocity.x, 7f);//player bounces in top direction 
                canMove = false;
                myBody.velocity = Vector2.zero;//This makes the snail to not move.
                anim.Play("stunAnimation");
                stun = true;
                // StartCoroutine(Dead(2.0f));
            }
        }
        pushSnail();
    }
      void pushSnail()
    {
        if (stun)
        {
            if (leftHit)
            {
                myBody.velocity = new Vector2(100f, myBody.velocity.y);
                StartCoroutine(Dead(2.0f));
            }
            if (rightHit)
            {
                myBody.velocity = new Vector2(-100f, myBody.velocity.y);
                StartCoroutine(Dead(2.0f));
            }

        }
      } 

    void playerDied()
    {
        if (!stun)
        {
            if (leftHit || rightHit)
            {
                if (leftHit)
                {
                    leftHit.gameObject.GetComponent<PlayerDamage>().damagePlayer();
                }
                if (rightHit)
                {
                    rightHit.gameObject.GetComponent<PlayerDamage>().damagePlayer();
                }
            }
        }
    }

    IEnumerator Dead(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == Tags.bomb_tag)
        {
            if (!stun)
            {
                myBody.velocity = Vector2.zero;
                canMove = false;
                anim.Play("stunAnimation");
                stun = true;
            }
            else
            {
                stun = false;
                StartCoroutine(Dead(0.05f));
            } 
        }
    }
}
