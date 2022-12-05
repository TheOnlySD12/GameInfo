using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Map : MonoBehaviour
{
    public void Back() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void LevelOne() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LevelOneTest() {
        SceneManager.LoadScene("SaveMoveTest");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
