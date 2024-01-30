using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class mainMenuControler : MonoBehaviour
{
    private AudioSource aud;
    [SerializeField] AudioClip gameSound;
    private bool playSound;
    public void Start()
    {
        playSound = true;
        aud = GetComponent<AudioSource>();
    }
   public void startStopSound()
    {
        playSound = !playSound;
        if (!playSound)
        {
            aud.Stop();
        }
        else
        {
            aud.Play();
        }
    }
    public void startGame()
    {
        SceneManager.LoadScene(1);

    }
    public void Quit()
    {
        Application.Quit();
    }
    public void howToPlay()
    {
        SceneManager.LoadScene(4);
    }
}
