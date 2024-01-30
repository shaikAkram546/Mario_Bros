using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class BulletScript : MonoBehaviour
{
    private float speed = 10f;
    Animator anim;

    private void Start()
    {
        StartCoroutine(freebullet(1.5f)); 
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();  
    }
    void Update()
    {
        move();
    }
    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }

    }
     void move()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == Tags.snail_tag|| target.tag == Tags.beetle_tag || target.tag == Tags.bird_tag||target.tag ==Tags.spider_tag||target.tag == Tags.hedgehog_tag||target.tag == Tags.bee_tag|| target.tag == Tags.vbird_tag|| target.tag == Tags.frog_tag|| target.tag == Tags.boss_tag )
        {
            anim.Play("BulletAnimation");
            StartCoroutine(freebullet(0.05f));

        }
    }
    public IEnumerator freebullet(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false); 
    }


        
    

}//class
