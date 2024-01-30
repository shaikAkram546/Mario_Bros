using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamePlayControler : MonoBehaviour
{
    public void pause()
    {
        Time.timeScale = 0;
    }
    public void Reset()
    {
        Time.timeScale = 1;
    }
    public void backHome()
    {
        SceneManager.LoadScene(0);
    }
}
