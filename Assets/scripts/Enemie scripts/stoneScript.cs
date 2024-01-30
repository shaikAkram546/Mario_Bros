using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneScript : MonoBehaviour
{
    private Rigidbody2D stone;
    private void Start()
    {
        stone = GetComponent<Rigidbody2D>();
        StartCoroutine(disableStone());
    }
    IEnumerator disableStone()
    {
        yield return new WaitForSeconds(2f);
        stone.gameObject.SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == Tags.player_tag)
        {
            stone.gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag(Tags.player_tag).gameObject.GetComponent<PlayerDamage>().damagePlayer();
        }
    }


}
