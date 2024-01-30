using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdScript : MonoBehaviour
{
    public float speed = 1f; // Adjust the speed as needed
    public float distance = 5f; // Adjust the distance the bird should move
    private Vector3 initialPosition;
    private bool movingForward = true;
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
        moveBird();
        DropEgg();
    }
    void moveBird()
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
        }
    }
    void DropEgg()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, playerLayer))
        {
            if (!attack)
            {
                Instantiate(birdEgg, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity);
                attack = true;
                anim.Play("birdWithout");
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Tags.bomb_tag)
        {
            anim.Play("birdDie");
            canMove = false;
            myBody.bodyType = RigidbodyType2D.Dynamic;
            StartCoroutine("birdDead");

        }
    }

    IEnumerator birdDead()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
