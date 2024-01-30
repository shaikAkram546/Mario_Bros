using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public Text NoBullet;
    public GameObject fireBullet;
     public int max = 50;
    private void Start()
    {
        
    }
    void Update()
    {

        playerShoot();
    }
    void playerShoot()
    {
        if(max>=0)
        { 
            if (Input.GetKeyDown(KeyCode.S))
            {
                NoBullet.text = "Bullets : " + max.ToString();
                max--;
                GameObject bullet;
                bullet = Instantiate(fireBullet, transform.position, Quaternion.identity);
                bullet.GetComponent<BulletScript>().Speed *= transform.localScale.x;
            }
        }
        else
        {

            NoBullet.text = "No Bullets.."  ;
        }
    }
}
