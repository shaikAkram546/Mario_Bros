using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D myBody;
    public GameObject stone;
    public Transform instantiatePostion;
    private bool play;
    private string coroutine_name = "attackTime";
    

   
    void Start()
    {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        StartCoroutine(coroutine_name);
    }

    void attack()
    {
       
        GameObject stoneAttack;
        stoneAttack = Instantiate(stone, instantiatePostion.position, Quaternion.identity);
        //stoneAttack.GetComponent<stoneScript>().Speed *= transform.position.x;
        stoneAttack.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-300f,-1000f),0f));//in this way also the force for the stone can be applied...
    }
    void playIdle()
    {

        anim.Play("BossWithOut");
        
    }
    IEnumerator attackTime()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        anim.Play("bossStone");
        StartCoroutine(coroutine_name);
    }
    public void killBoss()
    {
        StopCoroutine(coroutine_name);
        enabled = false;//this line makes the script disable/...
    }
    IEnumerator bossDie()
    {
       
        yield return new WaitForSeconds(2f);
        myBody.gameObject.SetActive(false);

    }
 
}
