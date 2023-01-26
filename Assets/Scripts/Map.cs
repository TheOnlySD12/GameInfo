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
        SceneManager.LoadScene("level 1");
    }
}
