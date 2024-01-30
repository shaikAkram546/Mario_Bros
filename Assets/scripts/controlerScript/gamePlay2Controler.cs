using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamePlay2Controler : MonoBehaviour
{
    public void puse()
    {
        Time.timeScale = 0;
    }
    public void reset()
    {
        Time.timeScale = 1;
    }
    public void backHome()
    {
        SceneManager.LoadScene(0);
    }
}
