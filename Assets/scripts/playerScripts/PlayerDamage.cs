using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private Text playerHealth;
    private bool canDamage;
    private int chances;
    private AudioSource aud;
    public AudioClip playerDamage;
    private void Awake()
    {
        playerHealth = GameObject.Find("playerScoreText").GetComponent<Text>();
        canDamage = true;
        chances = 3;
    }
    void Start()
    {
        Time.timeScale = 1;
        playerHealth.text = "X" + chances;
        aud = GetComponent<AudioSource>();
    }
    public void damagePlayer()
    {
        if (canDamage)
        {
            chances--;
            aud.PlayOneShot(playerDamage);
            if (chances >= 0)// this condition will make to not change the playerHealth text in negitive.
            {
                playerHealth.text = "X" + chances;
            }
            if(chances == 0)
            {
                Time.timeScale = 0;
                StartCoroutine(waitToloadScene());
            }
            canDamage = false;
            StartCoroutine(waitDamagePlayer());
        }
    }
    IEnumerator waitDamagePlayer()
    {
        yield return new WaitForSeconds(1f);
        canDamage = true;
    }
    IEnumerator waitToloadScene()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//loding the current index..

    }

}
