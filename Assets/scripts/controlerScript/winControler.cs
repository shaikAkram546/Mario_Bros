using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winControler : MonoBehaviour
{
    private AudioSource aud;
     
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void nextLevel()
    {
        SceneManager.LoadScene(2);
    }
    public void preLevel()
    {
        SceneManager.LoadScene(1);
    }
        
    
}
