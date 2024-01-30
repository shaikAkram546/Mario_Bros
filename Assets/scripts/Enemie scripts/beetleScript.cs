using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beetleScript : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Animator anim;
    public float speed = 0.2f;
    public Transform groundCheck, up_position; // left_position, right_position; (came From snail)
    private bool moveLeft, canMove, stun;
    public LayerMask playerLayer;
    private Collider2D upHit;
    void Start()
    {
        moveLeft = true;
        canMove = true;
    }
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
 // Update is called once per frame
    void Update()
    {
        playerMove();
        collision();
    }
    void playerMove()
    {
        if (canMove)
        {
            changeDirection();
            if (moveLeft)
            {
                myBody.velocity = new Vector2(-speed, myBody.velocity.y);

            }
            else
            {
                myBody.velocity = new Vector2(speed, myBody.velocity.y);
            }
        }
    }
    void changeDirection()
    {
        if (!Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f))
        {
            moveLeft = !moveLeft;
            Vector3 tempScale = transform.localScale;
            if (moveLeft)
            {
               tempScale.x = Mathf.Abs(tempScale.x);
            }
            else
            {
                tempScale.x = -Mathf.Abs(tempScale.x);
            }
            transform.localScale = tempScale;
        }

    }
    void collision()
    {
       upHit = Physics2D.OverlapCircle(up_position.position, 0.2f, playerLayer);
        if (!stun)
        {
            if (upHit == null)
            {
                if (Physics2D.OverlapCircle(transform.position, 0.5f, playerLayer))
                {
                    GameObject.FindGameObjectWithTag(Tags.player_tag).GetComponent<PlayerDamage>().damagePlayer();
                }
            }
            
        }

        
        if (upHit != null)
        {
            if (upHit.gameObject.tag == "player")
            {
                if (!stun)
                {
                    upHit.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(upHit.gameObject.GetComponent<Rigidbody2D>().velocity.x, 7f);
                    canMove = false;
                    myBody.velocity = new Vector2(0, 0);
                    anim.Play("beetleStun");
                    stun = true;
                }
            }
        }
       if (stun)
        {
            StartCoroutine(Dead(0.5f));

        }
    }
    IEnumerator Dead(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == Tags.bomb_tag)
        {
            StartCoroutine(Dead(0.05f));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Tags.snail_tag)
        {
            moveLeft = !moveLeft;
            Vector3 tempScale = transform.localScale;
            if (moveLeft)
            {
                tempScale.x = Mathf.Abs(tempScale.x);
            }
            else
            {
                tempScale.x = -Mathf.Abs(tempScale.x);
            }
            transform.localScale = tempScale;
        }
    }
}//class
























