using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D myBody;
    private string Coroutine_name = "changeDirection";
    private Vector3 direction = Vector3.down;
    private bool moveDown; 
    private void Awake()
    {
       
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        moveDown = true;
        StartCoroutine(Coroutine_name);
    }

    void Update()
    {
        move();
    }
    private void move()
    {
        transform.Translate(direction * Time.smoothDeltaTime);
    }
    IEnumerator changeDirection()
    {
        yield return new WaitForSeconds(Random.Range(1f, 2f));
        if (direction == Vector3.down)
        {
            direction = Vector3.up;
        }
        else
        {
            direction = Vector3.down;
        }
        StartCoroutine(Coroutine_name);
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == Tags.bomb_tag)
        {
            Die();
        }
        if(target.tag == Tags.player_tag)
        {
            //player damage...
          target.GetComponent<PlayerDamage>().damagePlayer();
            
        }
    }
    void Die()
    {
        anim.Play("spiderDie");
        StopCoroutine(Coroutine_name);
        myBody.bodyType = RigidbodyType2D.Dynamic;
        StartCoroutine(effect());


    }
    IEnumerator effect()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
