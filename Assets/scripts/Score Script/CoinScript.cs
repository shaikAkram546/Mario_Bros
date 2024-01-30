using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;
public class CoinScript : MonoBehaviour
{

    private AudioSource aud;
    public Text coinScore;
    public int score = 0;

 

    void Awake()
    {
        aud = GetComponent<AudioSource>();
        //myBody = GetComponent<Rigidbody2D>();
     
    }

    public void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == Tags.coin_tag)
        {
            score++;
            aud.Play();
            coinScore.text = "X" + score.ToString();
            target.gameObject.SetActive(false);

        }

    }
}