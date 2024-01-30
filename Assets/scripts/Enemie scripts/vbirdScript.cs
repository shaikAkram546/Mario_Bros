using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vbirdScript : MonoBehaviour
{
    public float speed = 1f; // Adjust the speed as needed
    public float distance = 5f; // Adjust the distance the bird should move
    private Vector3 initialPosition;
    private bool movingForward = true;
    private bool movingUp = true;
    public LayerMask playerLayer;
    private Rigidbody2D myBody;
    private Animator anim;
    public GameObject birdEgg;
    private bool attack, canMove = true;

    void Start()
    {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    void Update()
    {
        movevBirdForward();
       // vbirdMoveup();
    }
    void movevBirdForward()
    {
        if (canMove)
        {
            if (movingForward)
            {
                transform.Translate(Vector3.left * speed * Time.smoothDeltaTime);
            }
            else
            {
                transform.Translate(Vector3.right * speed * Time.smoothDeltaTime);
            }
            // Check if the bird reached the maximum distance
            if (Vector3.Distance(initialPosition, transform.position) >= distance)
            {
                movingForward = !movingForward;
                Vector3 temp = transform.localScale;
                if (movingForward)
                {
                    temp.x = Mathf.Abs(temp.x);
                }
                else
                {
                    temp.x = -Mathf.Abs(temp.x);
                }
                transform.localScale = temp;
            }
            if (movingUp)
            {
                transform.Translate(Vector3.up * speed * Time.smoothDeltaTime);
            }
            else
            {
                transform.Translate(Vector3.down * speed * Time.smoothDeltaTime);
            }

            // Check if the bird reached the maximum distance
            if (Vector3.Distance(initialPosition, transform.position) >= distance)
            {
                movingUp = !movingUp;
                Vector3 temp = transform.localScale;
                if (movingForward)
                {
                    temp.x = Mathf.Abs(temp.y);
                }
                else
                {
                    temp.x = -Mathf.Abs(temp.y);
                }
                transform.localScale = temp;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Tags.bomb_tag)
        {
            anim.Play("vbirdDie");
            canMove = false;
            myBody.bodyType = RigidbodyType2D.Dynamic;
            StartCoroutine("vbirdDead");
        }
        if(collision.tag == Tags.player_tag)
        {
            collision.GetComponent<PlayerDamage>().damagePlayer();
        }
    }

    IEnumerator vbirdDead()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
