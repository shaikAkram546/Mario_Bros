using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : MonoBehaviour
{
    private Rigidbody2D myBody;
    public LayerMask playerLayer;
    private bool  damage;
    // Start is called before the first frame update
    void Start()
    { 
        myBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        StartCoroutine("eggGone");
        damagePlayer();
        
    }
    void damagePlayer()
    {
        damage = Physics2D.OverlapCircle(transform.position, 0.5f, playerLayer);
        if (damage)
        {
             GameObject.FindGameObjectWithTag(Tags.player_tag).GetComponent<PlayerDamage>().damagePlayer();
            
        }
    }

     
    IEnumerator eggGone()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);

    }
}
