using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SMOther : MonoBehaviour { 
    public void PlayGame()
    {
        SceneManager.LoadScene("Map");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Back2Menu()
    {
        SceneManager.LoadScene("SavesMenu");
    }
}
