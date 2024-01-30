using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHealth : MonoBehaviour
{
    private int killBoss;
    private Animator anim;
    private Rigidbody2D myBody;
    void Start()
    {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }

    
    IEnumerator disableBoss()
    {
        yield return new WaitForSeconds(2f);
        myBody.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == Tags.bomb_tag)
        {
            killBoss++;
        }
        if (killBoss == 3)
        {
            GetComponent<BossScript>().killBoss();
            anim.Play("bossDie");
            StartCoroutine(disableBoss());
        }

    }
}
