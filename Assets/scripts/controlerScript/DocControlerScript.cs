using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DocControlerScript : MonoBehaviour
{
    public void getBack()
    {
        SceneManager.LoadScene(0);
    }
}
