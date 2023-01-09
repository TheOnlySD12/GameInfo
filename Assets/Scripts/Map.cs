using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Map : MonoBehaviour
{
    public void Back() {
        SceneManager.LoadScene("SavesMenu");
    }

    public void LevelOne() {
        SceneManager.LoadScene("movement test");
    }
    public void QuitGame() {
        Application.Quit();
    }
}
