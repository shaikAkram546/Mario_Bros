using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerWalk : MonoBehaviour
{
   
    public float speed = 5f;
    private Rigidbody2D myBody;
    private Animator anim;
    public Transform groundPosition;
    public LayerMask groundLayer;
    public float jumpPower = 5f;
    public AudioSource aud;
    [SerializeField] AudioClip jumpClip,bonusClip,gameOverClip;



    void Awake()// creation of reference in this function.
    {
        myBody = GetComponent<Rigidbody2D>(); // reference has given to mybody 
        anim = GetComponent<Animator>();  // reference has given to mybody  for the animation 
        aud = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerMove();
       
    }
    void Update()
    {
        playerJump();
         

    }
    void playerMove()
    {
        float h = Input.GetAxis("Horizontal");
        if (h < 0)
        {
            myBody.velocity = new Vector2(-speed, myBody.velocity.y);
            changeDirection(-1);
        }
        else if (h > 0)
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
            changeDirection(1);
        }
        else if (h == 0)
        {
            myBody.velocity = new Vector2(0f, myBody.velocity.y);

        }
        anim.SetInteger("speed", Mathf.Abs((int)myBody.velocity.x)); // This line make the Walk animation

    }
    void changeDirection(int Direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = Direction;
        transform.localScale = tempScale;
    }
    void playerJump()
    {
        if (Physics2D.Raycast(groundPosition.position, Vector2.down, 0.1f, groundLayer))
        {
            anim.SetBool("jump", false);
            if (Input.GetKey(KeyCode.UpArrow))
            {
                aud.PlayOneShot(jumpClip);// this line makes to play selected clip. 
                myBody.velocity = new Vector2(myBody.velocity.x, jumpPower);
            }
        }
        else
        {
            anim.SetBool("jump", true);
            if (Input.GetKey(KeyCode.DownArrow))
            {
                myBody.velocity = new Vector2(myBody.velocity.x, -jumpPower);
            }

        }
    }
    public void playBonousSound()
    {
        aud.PlayOneShot(bonusClip);
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == Tags.water_tag)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//this line will load the current scene..
        }
        if(target.tag == Tags.end_tag)
        {
            SceneManager.LoadScene(3);
            // print("game ended");
            aud.PlayOneShot(gameOverClip);
        }
        
    }
   



}//class
















